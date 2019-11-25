using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3
{
    public class HelloController: Controller
    {
        //[HttpGet("/hello")]
        //public string SayHello() => "Hello World";

        [HttpGet("/hello/{name}")]
        public IActionResult SayHello(string name)
        {
            Random r1 = new Random();
            int a1 = r1.Next(1, 100);
            ViewBag.Name = a1.ToString();
            return View();
        }
    }
}
