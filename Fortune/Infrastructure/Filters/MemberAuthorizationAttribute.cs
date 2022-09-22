using Fortune.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fortune.Infrastructure.Filters
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authService = context.HttpContext.RequestServices.GetService<IAuthorizationService>();

            var headers = context.HttpContext.Request.Headers;

            string authorizationHeader = headers["Authorization"];

            if (authorizationHeader == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
            else
            {
                var token = authorizationHeader.Split(' ')[1];

                bool isOk = authService.CheckToken(token);

                if (!isOk)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                }

               
            }

        }

    }
}
