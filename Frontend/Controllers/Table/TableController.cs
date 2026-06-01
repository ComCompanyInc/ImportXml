using BackendApp.Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Frontend.Controllers.Table
{
    public class TableController : Controller
    {
        private readonly RenderTableService _renderTableService;

        public TableController(RenderTableService renderTableService) {
            _renderTableService = renderTableService;
        }

        //localhost:5000/Table/GetTable
        public async Task<IActionResult> GetTable(string tableId) //добавляем параметр для представления
        {
            List<object> tableData = await _renderTableService.GetDataByTableName(tableId);

            // Передаём параметр в представление через ViewBag
            ViewBag.TableId = tableId;
            ViewBag.TableData = tableData;

            return View("~/Frontend/Views/Table/Table.cshtml");
        }
    }
}
