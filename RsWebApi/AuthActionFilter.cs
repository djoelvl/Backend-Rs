using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace RsWebApi
{
    public class AuthActionFilter : IActionFilter
    {
        List<string> segments = new List<string> { "/api/user/getlogin", "/api/user/createuser" };


        public IConfiguration ConfigRoot { get; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var req = context.HttpContext.Request;

            //if (segments.Contains(req.Path.ToString().ToLower()))
            //    return;

            if (!req.IsAuthenticated() && !segments.Contains(req.Path.ToString().ToLower()) )
            {
                context.Result = new UnauthorizedObjectResult("No tiene privilegios para ejecutar esta acción");
            }

        }


        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
