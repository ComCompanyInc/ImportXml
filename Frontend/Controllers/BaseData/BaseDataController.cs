using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Frontend.Controllers.BaseData
{
    public class BaseDataController : Controller
    {
        // GET: /BaseData/All
        public IActionResult GetTable()
        {
            return View("~/Frontend/Views/BaseData/BaseDataPage.cshtml");
        }
    }
}
