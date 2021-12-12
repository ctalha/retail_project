using Microsoft.AspNetCore.Builder;
using Retail.Core.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.Extentions
{
    public static class CustomExceptionExtention
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomException>();
        }
    }
}
