using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BackendApp.Frontend.Services
{
    public class RenderTableService
    {
        private readonly F031_ErmosService _f031_ErmosService;
        private readonly F032_TrmosService _f032_TrmosService;

        public RenderTableService(
            F031_ErmosService f031_ErmosService,
            F032_TrmosService f032_TrmosService
        )
        {
            _f031_ErmosService = f031_ErmosService;
            _f032_TrmosService = f032_TrmosService;
        }

        public async Task<List<object>> GetDataByTableName(string TableName, string filterJson)
        {
            Dictionary<string, object> filter;

            switch (TableName)
            {
                case "F031":

                    filter = filterJson != null
                        ? JsonSerializer.Deserialize<Dictionary<string, object>>(filterJson)
                        : null;

                    // Выбираем ТОЛЬКО нужные поля
                    return await _f031_ErmosService.GetDataBySearchFilter(filter);

                case "F032":

                    filter = filterJson != null
                           ? JsonSerializer.Deserialize<Dictionary<string, object>>(filterJson)
                           : null;

                    // Выбираем ТОЛЬКО нужные поля
                    return await _f032_TrmosService.GetDataBySearchFilter(filter);

                default:
                    return new List<object>();

            }
        }
    }
}
