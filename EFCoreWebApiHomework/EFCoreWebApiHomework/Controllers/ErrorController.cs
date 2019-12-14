using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace EFCoreWebApiHomework.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ErrorController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        [Route("~/error")]
        public IActionResult Index()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var isDevelopment = this.webHostEnvironment.IsDevelopment();

            return this.Problem(
                isDevelopment ? ex.StackTrace : null,
                feature?.Path,
                (int?)HttpStatusCode.InternalServerError,
                isDevelopment ? $"{ex.GetBaseException().GetType().Name}: {ex.GetBaseException().Message}" : "An error occurred.");
        }

        [Route("~/exception")]
        public IActionResult Exception()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var isDevelopment = this.webHostEnvironment.IsDevelopment();

            var problem = new ProblemDetails
                          {
                              Status = (int?)HttpStatusCode.InternalServerError,
                              Instance = feature?.Path,
                              Title = isDevelopment ? $"{ex.GetBaseException().GetType().Name}: {ex.GetBaseException().Message}" : "An error occurred.",
                              Detail = isDevelopment ? ex.StackTrace : null
                          };

            return this.StatusCode(problem.Status.Value, problem);
        }
    }
}