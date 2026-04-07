using BackendApp.Dto;
using BackendApp.Dto.f031_ermos;
using BackendApp.Dto.f032_trmos;
using BackendApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class F032_TrmosController
    {
        private readonly F032_TrmosService _f032_TrmosService;

        public F032_TrmosController(F032_TrmosService f032_TrmosService)
        {
            _f032_TrmosService = f032_TrmosService;
        }

        [HttpPost("import/F32")]
        [Consumes("application/xml")]
        public async Task<bool> ImportXmlData([FromBody] DocumentDto<F32DataDto> dataContainer)
        {
            //return dataContainer;

            return await _f032_TrmosService.SaveDataFromF32(dataContainer);

            //return true;
        }
    }
}
