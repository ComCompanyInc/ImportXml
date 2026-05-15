using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Frontend.Controllers
{
    public class MainPageController : Controller
    {
        // GET: /MainPage/Index
        public IActionResult Index()
        {
            return View("~/Frontend/Views/MainPage/Index.cshtml");
        }
    }
}
