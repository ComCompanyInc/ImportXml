using BackendApp.Dto;
using BackendApp.Dto.f031_ermos;
using BackendApp.Dto.f032_trmos;
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
    public class F032_TrmosController : ControllerBase
    {
        private readonly F032_TrmosService _f032_TrmosService;

        public F032_TrmosController(F032_TrmosService f032_TrmosService)
        {
            _f032_TrmosService = f032_TrmosService;
        }

        /// <summary>
        /// Импорт данных документа f032_trmo на основании ссылок на документ f031_ermo (IDMO -> F031_Ermos.Id)
        /// Сначала импортируем справочник f031_ermo, и тоько после его заполнения, заполняем f032_trmo
        /// </summary>
        /// <returns></returns>
        [HttpPost("import/F32")]
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
            XmlSerializer serializer = new XmlSerializer(typeof(DocumentDto<F32DataDto>)); // приводим данные потока к классу-сериализатору xml в обьект XmlSerializer
            DocumentDto<F32DataDto> dataContainer = (DocumentDto<F32DataDto>)serializer.Deserialize(stringReader); // при помощи класса XmlSerializer - сериализуем наш обьект в DocumentDto<F31DataDto>
            stringReader.Close(); // ОБЯЗАТЕЛЬНО закрываем

            //return dataContainer;

            // 3. Сохраняем данные
            return await _f032_TrmosService.SaveDataFromF32(dataContainer);
        }
    }
}
