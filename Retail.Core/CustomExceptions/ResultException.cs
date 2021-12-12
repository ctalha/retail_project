using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.CustomExceptions
{
    public class ResultException : Exception
    {
        public bool IsSuccessed { get; }

        public bool IsShow { get; }

        public string Messages { get; }
        public ResultException(bool isShow, string messages)
        {
            IsSuccessed = false;
            IsShow = isShow;
            Messages = messages;
        }
        public ResultException(bool isShow)
        {
            IsSuccessed = false;
            IsShow = isShow;
            
        }
    }
}
