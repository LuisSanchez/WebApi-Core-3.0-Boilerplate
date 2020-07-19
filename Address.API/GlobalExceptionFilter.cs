using Address.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Address.API
{
    /// <summary>
    /// Filtro para tratamiento genérico de excepciones
    /// </summary>
    public class GlobalExceptionFilter: ExceptionFilterAttribute
    {
        /// <summary>
        /// Handles all exceptions on the api.
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(ExceptionContext actionExecutedContext)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(JsonConvert.SerializeObject(new { 
                    actionExecutedContext.Exception.Message, 
                    Inner = actionExecutedContext.Exception.GetInnerExceptions() })),
            };

            actionExecutedContext.Result = new HttpResponseMessageResult(response); ;

            base.OnException(actionExecutedContext);
        }
    }

    /// <summary>
    /// Snippet that gets all the exceptions when an error occurs.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Yields all inner exceptions.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static IEnumerable<Exception> GetInnerExceptions(this Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException("ex");
            }

            var innerException = ex;
            do
            {
                yield return innerException;
                innerException = innerException.InnerException;
            }
            while (innerException != null);
        }
    }
}