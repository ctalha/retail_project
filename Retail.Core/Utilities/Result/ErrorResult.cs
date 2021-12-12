using Retail.Core.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.Utilities.Result
{
    public class ErrorResponse : Response
    {
        public ErrorResponse(bool isShow, string messages):base(false,isShow,messages)
        {
        }
        public ErrorResponse(bool isShow) : base(false, isShow)
        {
        }
    }
}
