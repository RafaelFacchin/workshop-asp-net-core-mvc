using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S18_SalesWeb_MVC.Models;

namespace S18_SalesWeb_MVC.Controller
{
    public class HomeController : Controller
    {
        //****METODOS
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Salles web MVC app from C# course.";
            ViewData["User"] = "aaa@bbb.com";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
