using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.Utilities.Result
{
    public class Response : IResponse
    {
        public bool IsSuccessed { get; }

        public bool IsShow { get; }

        public string Messages { get; }

        public Response(bool isSuccessed,bool isShow, string messages) : this(isSuccessed, isShow)
        {
            IsSuccessed = isSuccessed;
            IsShow = isShow;
            Messages = messages;
        }

        public Response(bool isSuccessed, bool isShow)
        {
            IsSuccessed = isSuccessed;
            IsShow = isShow;
        }
        public Response(bool isSuccessed)
        {
            IsSuccessed = isSuccessed;
        }
    }
}
