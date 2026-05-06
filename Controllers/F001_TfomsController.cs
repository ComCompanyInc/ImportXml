using Azure.Core;
using BackendApp.Dto;
using BackendApp.Dto.f001_tfoms;
using BackendApp.Dto.f002_smo_emp;
using BackendApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class F001_TfomsController : ControllerBase
    {
        private readonly F001_TfomsService _f001_TfomsService;

        public F001_TfomsController(F001_TfomsService f001_TfomsService)
        {
            _f001_TfomsService = f001_TfomsService;
        }

        [HttpPost("import/F1")]
        [Consumes("application/xml")]
        public async Task<List<ErrorResponseDto>> ImportXmlData()
        {
            // РЕГИСТРИРУЕМ КОДИРОВКУ windows-1251 (всего одна строчка!)
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // 1. Создаем StreamReader для чтения тела запроса в кодировке windows-1251 (Request.Body - тело запроса от клиента - в нашем случае там будет сырой xml)
            StreamReader reader = new StreamReader(Request.Body, Encoding.GetEncoding("windows-1251"));
            string xmlContent = await reader.ReadToEndAsync(); // конвертируем прочтенные данные в фортаме строки
            reader.Close(); // ОБЯЗАТЕЛЬНО закрываем, чтобы освободить ресурсы

            // 2. Создаем StringReader для десериализации (приведение полученной xml-строки в кодировке windows-1251 в POCO-обьект DocumentDto<F31DataDto>)
            StringReader stringReader = new StringReader(xmlContent); // в поток передаем строку с полученым xml в нужной нам кодировке windows-1251
            XmlSerializer serializer = new XmlSerializer(typeof(F1Document)); // приводим данные потока к классу-сериализатору xml в обьект XmlSerializer
            F1Document dataContainer = (F1Document)serializer.Deserialize(stringReader); // при помощи класса XmlSerializer - сериализуем наш обьект в DocumentDto<F31DataDto>
            stringReader.Close(); // ОБЯЗАТЕЛЬНО закрываем

            // 3. Сохраняем данные
            return await _f001_TfomsService.SaveDataFromF1(dataContainer);
        }
    }
}
