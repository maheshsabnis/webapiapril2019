using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace WebApiApp.CustomFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Debug.WriteLine($"The Action is Executing. The Current Action is {actionContext.ActionDescriptor.ActionName}" +
                $" Under the Controller {actionContext.ActionDescriptor.ControllerDescriptor.ControllerName}");
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Debug.WriteLine($"The Action is Executed. The Current Action is {actionExecutedContext.ActionContext.ActionDescriptor.ActionName}" +
                $" Under the Controller {actionExecutedContext.ActionContext.ActionDescriptor.ActionName}");
        }
    }
}