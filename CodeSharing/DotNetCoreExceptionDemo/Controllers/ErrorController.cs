using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreExceptionDemo.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreExceptionDemo.Controllers
{
    [Route("/error")]
    public class ErrorController : Controller
    {
        /// <summary>
        /// 异常处理页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var exception= HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = exception?.Error;
            var knowException = ex as IKnownException;
            if (knowException==null)
            {
                var logger = HttpContext.RequestServices.GetService<ILogger<MyExceptionFilterAttribute>>();
                logger.LogError(ex, ex.Message);
                knowException = KnownException.Unknown;
            }
            else
            {
                knowException = KnownException.FromKnownException(knowException);
            }
            return View(knowException);
        }
    }
}