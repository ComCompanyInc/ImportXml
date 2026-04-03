using BackendApp.Dto;
using BackendApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class F031_ErmosComtroller : ControllerBase
    {
        private readonly F031_ErmosService _f031_ErmosService;

        public F031_ErmosComtroller(F031_ErmosService f031_ErmosService)
        {
            _f031_ErmosService = f031_ErmosService;
        }

        [HttpPost("import")]
        [Consumes("application/xml")]
        public async Task<bool> ImportXmlData([FromBody] f031_ermoDto dataContainer)
        {
            //return dataContainer;

            return await _f031_ErmosService.SaveDataFromF31(dataContainer);
        }
    }
}
