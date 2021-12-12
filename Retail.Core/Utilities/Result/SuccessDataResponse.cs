using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.Utilities.Result
{
    public class SuccessDataResponse<T> : DataResponse<T>
    {
        public SuccessDataResponse(T data, bool isShow,string messages):base(data,true,isShow,messages)
        {

        }
        public SuccessDataResponse(T data, bool isShow) : base(data, true, isShow)
        {

        }
    }
}
