using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCoreWebApiHomework.Filters
{
    public class LoginAttribute : IActionFilter
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