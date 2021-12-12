using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.Utilities.Result
{
    public class SuccessResponse : Response
    {
        public SuccessResponse(bool isShow, string messages) : base(true,isShow,messages)
        {

        }

        public SuccessResponse(bool isShow) : base(true,isShow)
        {

        }
        public SuccessResponse() : base(true)
        {

        }
    }
}
