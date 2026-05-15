using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Frontend.Controllers.Import
{
    public class ImportController : Controller
    {
        // GET: /Import/All
        public IActionResult All()
        {
            return View("~/Frontend/Views/Import/ImportPage.cshtml");
        }
    }
}
