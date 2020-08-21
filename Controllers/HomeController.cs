using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EF_LINQ_OPS.Models;

namespace EF_LINQ_OPS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult BeersIndex2()
        {
            return View();
        }
        public IActionResult Beers()
        {
            return View();
        }
       
        public IActionResult Indian()
        {
            return View();
        }
        public IActionResult Japanese()
        {
            return View();
        }
        public IActionResult Mexican()
        {
            return View();
        }
        public IActionResult Chart()
        {
            return View();
        }
    }
}

