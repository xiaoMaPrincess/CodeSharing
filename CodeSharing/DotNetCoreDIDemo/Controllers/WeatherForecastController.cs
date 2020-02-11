using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDIDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetCoreDIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISingletonService singletonService;
        private readonly IScopedService scopedService;
        private readonly ITransientService transientService;
        /// <summary>
        /// 两种注入方式：构造函数注入....FromServices注入....
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="_singletonService"></param>
        /// <param name="_scopedService"></param>
        /// <param name="_transientService"></param>
        /// <param name="_singletonService2"></param>
        /// <param name="_scopedService2"></param>
        /// <param name="_transientService2"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISingletonService _singletonService, IScopedService _scopedService, ITransientService _transientService, ISingletonService _singletonService2, IScopedService _scopedService2, ITransientService _transientService2)
        {
            Console.WriteLine($"singleton:{_singletonService.GetHashCode()}");
            Console.WriteLine($"singleton:{_singletonService2.GetHashCode()}");
            Console.WriteLine($"scoped:{_scopedService.GetHashCode()}");
            Console.WriteLine($"scoped:{_scopedService2.GetHashCode()}");
            Console.WriteLine($"transient:{_transientService.GetHashCode()}");
            Console.WriteLine($"transient:{_transientService2.GetHashCode()}");
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogError("heiheihi");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
                }
        [HttpGet]
        public string GetServices()
        {
            return "services";
        }
        [HttpGet]
        public List<string> GetHello()
        {
            List<string> vs = new List<string>();
            vs.Add("heiheihei");
            return vs;
        }
    }
}
