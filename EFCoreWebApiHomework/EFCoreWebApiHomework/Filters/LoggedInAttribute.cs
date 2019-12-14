using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCoreWebApiHomework.Filters
{
    public class LoggedInAttribute : TypeFilterAttribute
    {
        public LoggedInAttribute()
            : base(typeof(LoggedInAttributeImpl))
        {
        }

        private class LoggedInAttributeImpl : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
                // ...
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                // ...
            }
        }
    }
}