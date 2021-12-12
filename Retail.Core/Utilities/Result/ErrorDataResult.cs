using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResponse<T>
    {
        public ErrorDataResult(T data, bool isShow, string messages) : base(data, false, isShow, messages)
        {

        }
        public ErrorDataResult(T data, bool isShow):base(data,false,isShow)
        {

        }
    }
}
