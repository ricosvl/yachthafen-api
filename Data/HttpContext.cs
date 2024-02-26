using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Data
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class HttpContext : FormatFilterAttribute, IActionFilter
	{
		public HttpContext()
		{
		}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var user = httpContext.User;

            // Hier kannst du die Benutzerinformationen verwenden oder an die Aktion weitergeben
            context.ActionArguments["loggedInUser"] = user;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Optional: Hier könntest du nach der Ausführung der Aktion zusätzliche Logik hinzufügen
        }
    }
}




