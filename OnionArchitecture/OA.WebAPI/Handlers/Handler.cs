using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Web;
using System.Diagnostics;
using OA.Data.Model;
using OA.Service.Helpers;



namespace OA.WebAPI.Handlers
{
    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        //protected override async Task<HttpResponseMessage> SendAsync(
        //    HttpRequestMessage request, CancellationToken cancellationToken)
        //{
        //    // log request body
        //    string requestBody = await request.Content.ReadAsStringAsync();
        //    Trace.WriteLine(requestBody);

        //    var log = new Log
        //    {
        //        Id = 1,
        //        RequestIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Helper.GetIpAddress(),
        //        RequestUri = request.RequestUri.ToString(),
        //        RequestMethod = request.Method.Method,
        //        RequestPostData = Helper.Encrypt(requestBody),
        //        RequestTimestamp = DateTime.Now
        //    };


        //    // let other handlers process the request
        //    var result = await base.SendAsync(request, cancellationToken);

        //    if (result.Content != null)
        //    {
        //        // once response body is ready, log it
        //        var responseBody = await result.Content.ReadAsStringAsync();
        //        Trace.WriteLine(responseBody);


        //        object content;
        //        string errorMessage = null;
        //        string messageDetail = null;
        //        if (result.TryGetContentValue(out content) && !result.IsSuccessStatusCode)
        //        {
        //            HttpError error = content as HttpError;
        //            if (error != null)
        //            {
        //                messageDetail = error.MessageDetail;
        //                errorMessage = error.Message;
        //                errorMessage = string.Concat(errorMessage, error.ExceptionMessage, error.StackTrace);
        //            }
        //        }
        //        if (messageDetail != "No route data was found for this request.")
        //        {
        //            log.ResponseStatusCode = (int)result.StatusCode;
        //            log.ResponseReasonPhrase = result.ReasonPhrase;
        //            log.ResponseErrorMessage = errorMessage;
        //            log.ResponseTimestamp = DateTime.Now;
        //            IGenericRepository<Log> repository = new GenericRepository<Log>();
        //            await repository.Insert(log);
        //        }
        //    }

        //    return result;
        //}
    }
}