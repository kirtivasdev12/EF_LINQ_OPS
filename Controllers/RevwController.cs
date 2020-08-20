using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EF_LINQ_OPS.Controllers
{
    public class RevwController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
