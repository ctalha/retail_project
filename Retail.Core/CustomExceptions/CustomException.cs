using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Retail.Core.Utilities.Result;

namespace Retail.Core.CustomExceptions
{
    public class CustomException
    {
        private RequestDelegate _next;

        public CustomException(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            using (var tscope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await _next(httpContext);
                    tscope.Complete();
                 

                }
                catch (Exception e)
                {
                    tscope.Dispose();
                    await HandleExceptionAsync(httpContext, e);
            }
        }
    }



        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (e.GetType() == typeof(ValidationException))
            {
                
                ValidationErrorDetail validationErrorDetail = new ValidationErrorDetail
                {
                    Errors = ((ValidationException)e).Errors,
                    Messages = "Validation Error",
                    StatusCode = 400
                };
                var json = JsonSerializer.Serialize(validationErrorDetail);
                return context.Response.WriteAsync(json);
            }
            else if (e.GetType() == typeof(ResultException))
            {

                Response responseError = new Response(((ResultException)e).IsSuccessed, ((ResultException)e).IsShow, ((ResultException)e).Messages);
                var json = JsonSerializer.Serialize(responseError);
                return context.Response.WriteAsync(json);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ErrorDetail errorDetail = new ErrorDetail
                {
                    Messages = e.Message,//internalservererror
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                var json = JsonSerializer.Serialize(errorDetail);
                return context.Response.WriteAsync(json);
            }



        }
    }
 }
