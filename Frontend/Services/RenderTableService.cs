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

        public RenderTableService(F031_ErmosService f031_ErmosService)
        {
            _f031_ErmosService = f031_ErmosService;
        }

        public async Task<List<object>> GetDataByTableName(string TableName, string filterJson)
        {

            switch (TableName)
            {
                case "F031":
                    Dictionary<string, object> filter;

                    filter = filterJson != null
                        ? JsonSerializer.Deserialize<Dictionary<string, object>>(filterJson)
                        : null;

                    // Выбираем ТОЛЬКО нужные поля
                    return await _f031_ErmosService.GetDataBySearchFilter(filter);

                //case "F032":
                //    // Получаем список F032 и приводим к List<object>
                //    return _context.F032_Trmos.Cast<object>().ToList();

                default:
                    return new List<object>();

            }
        }
    }
}
