using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiApp.CustomFilters
{
    public class GenericExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage response = null;
            if (actionExecutedContext.Exception.GetType() == typeof(ProcessException))
            {
                var message = actionExecutedContext.Exception.Message;
                 response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(message),
                    ReasonPhrase = message
                };
            }
            actionExecutedContext.Response = response;
        }
    }
}