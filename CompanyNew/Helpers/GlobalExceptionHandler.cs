using CompanyNew.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace CompanyNew.Helpers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            Exception exception = context.Exception;

            HttpStatusCode statusCode;

            if (exception is Common.Exceptions.ValidationException)
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (exception is RuntimeException)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            else if (exception is Common.Exceptions.AuthenticationException)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (exception is ForbiddenException)
            {
                statusCode = HttpStatusCode.Forbidden;
            }
            else if (exception is ServiceUnavailableException)
            {
                statusCode = HttpStatusCode.ServiceUnavailable;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

#if !DEBUG
            context.Result = new ResponseMessageResult(context.Request.CreateErrorResponse(statusCode, exception.Message));
            return;
#endif

            string message = exception.Message;
            exception = exception.InnerException;
            while (exception != null)
            {
                message += $"; {exception.Message}";
                exception = exception.InnerException;
            }

            context.Result = new ResponseMessageResult(context.Request.CreateErrorResponse(statusCode, message));
        }
    }
}