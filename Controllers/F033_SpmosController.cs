using BackendApp.Dto;
using BackendApp.Dto.f032_trmos;
using BackendApp.Dto.f033_spmo;
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
    public class F033_SpmosController : ControllerBase
    {
        private readonly F033_SpmosService _f033_spmosService;

        public F033_SpmosController(F033_SpmosService f033_spmosService)
        {
            _f033_spmosService = f033_spmosService;
        }

        [HttpPost("import/F33")]
        [Consumes("application/xml")]
        public async Task<bool> ImportXmlData()
        {
            // РЕГИСТРИРУЕМ КОДИРОВКУ windows-1251 (всего одна строчка!)
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // 1. Создаем StreamReader для чтения тела запроса в кодировке windows-1251 (Request.Body - тело запроса от клиента - в нашем случае там будет сырой xml)
            StreamReader reader = new StreamReader(Request.Body, Encoding.GetEncoding("windows-1251"));
            string xmlContent = await reader.ReadToEndAsync(); // конвертируем прочтенные данные в фортаме строки
            reader.Close(); // ОБЯЗАТЕЛЬНО закрываем, чтобы освободить ресурсы

            // 2. Создаем StringReader для десериализации (приведение полученной xml-строки в кодировке windows-1251 в POCO-обьект DocumentDto<F31DataDto>)
            StringReader stringReader = new StringReader(xmlContent); // в поток передаем строку с полученым xml в нужной нам кодировке windows-1251
            XmlSerializer serializer = new XmlSerializer(typeof(DocumentDto<F33DataDto>)); // приводим данные потока к классу-сериализатору xml в обьект XmlSerializer
            DocumentDto<F33DataDto> dataContainer = (DocumentDto<F33DataDto>)serializer.Deserialize(stringReader); // при помощи класса XmlSerializer - сериализуем наш обьект в DocumentDto<F31DataDto>
            stringReader.Close(); // ОБЯЗАТЕЛЬНО закрываем

            //return dataContainer;

            // 3. Сохраняем данные
            return await _f033_spmosService.SaveDataFromF33(dataContainer);
        }
    }
}
