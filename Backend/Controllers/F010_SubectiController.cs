using Azure.Core;
using BackendApp.Dto;
using BackendApp.Dto.f010_subecti;
using BackendApp.Dto.f031_ermos;
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
    public class F010_SubectiController : ControllerBase
    {
        private readonly F010_SubectiService _f010_SubectiService;

        public F010_SubectiController(F010_SubectiService f010_SubectiService)
        {
            _f010_SubectiService = f010_SubectiService;
        }

        [HttpPost("import/F10")]
        [Consumes("application/xml")]
        public async Task<bool /*DocumentDto<F31DataDto>*/> ImportXmlData(/*[FromBody] DocumentDto<F31DataDto> dataContainer*/)
        {
            // РЕГИСТРИРУЕМ КОДИРОВКУ windows-1251 (всего одна строчка!)
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // 1. Создаем StreamReader для чтения тела запроса в кодировке windows-1251 (Request.Body - тело запроса от клиента - в нашем случае там будет сырой xml)
            StreamReader reader = new StreamReader(Request.Body, Encoding.GetEncoding("windows-1251"));
            string xmlContent = await reader.ReadToEndAsync(); // конвертируем прочтенные данные в фортаме строки
            reader.Close(); // ОБЯЗАТЕЛЬНО закрываем, чтобы освободить ресурсы

            // 2. Создаем StringReader для десериализации (приведение полученной xml-строки в кодировке windows-1251 в POCO-обьект DocumentDto<F31DataDto>)
            StringReader stringReader = new StringReader(xmlContent); // в поток передаем строку с полученым xml в нужной нам кодировке windows-1251
            XmlSerializer serializer = new XmlSerializer(typeof(DocumentDto<F10DataDto>)); // приводим данные потока к классу-сериализатору xml в обьект XmlSerializer
            DocumentDto<F10DataDto> dataContainer = (DocumentDto<F10DataDto>)serializer.Deserialize(stringReader); // при помощи класса XmlSerializer - сериализуем наш обьект в DocumentDto<F31DataDto>
            stringReader.Close(); // ОБЯЗАТЕЛЬНО закрываем

            //return dataContainer;

            // 3. Сохраняем данные
            return await _f010_SubectiService.SaveDataFromF10(dataContainer);
        }
    }
}
