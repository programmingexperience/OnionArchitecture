using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using OA.Service.Interfaces;

namespace OA.WebAPI.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            if (!actionContext.ModelState.IsValid)
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            var exType = context.Exception.GetType();
            if (exType == typeof(UnauthorizedAccessException))
                status = HttpStatusCode.Unauthorized;
            else if (exType == typeof(ArgumentException))
                status = HttpStatusCode.NotFound;
            var apiError = new ApiErrorMessage()
            {
                RequestUri = context.Request.RequestUri.ToString(),
                Method = context.Request.Method.ToString(),
                PostData = JsonConvert.SerializeObject(context.ActionContext.ActionArguments.Values),
                Exception = context.Exception.Message
            };
            // create a new response and attach our ApiError object
            // which now gets returned on ANY exception result
            var errorResponse = context.Request.CreateResponse(status, apiError);
            context.Response = errorResponse;
            base.OnException(context);
        }
        public class ApiErrorMessage
        {
            public string Version { get { return "1.0"; } }
            public string RequestUri { get; set; }
            public string Method { get; set; }
            public string PostData { get; set; }
            public string Exception { get; set; }
        }
    }
}