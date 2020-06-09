using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Controllers
{
    public class HelloController:Controller
    {
        [HttpGet("/Hello/{name?}")]
        public IActionResult SayHello(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
