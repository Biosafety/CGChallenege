using ApiCodeChallenge.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiCodeChallenge.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var req = context.HttpContext.Request;

            if (!req.Headers[HeaderValues.AUTH_HEADER].Any())
            {
                context.Result = new UnauthorizedObjectResult(new ErrorResponse(HttpStatusCode.Unauthorized));
            }

            base.OnActionExecuting(context);
        }
    }
}
