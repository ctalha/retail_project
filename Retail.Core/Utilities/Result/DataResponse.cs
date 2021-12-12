using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.Utilities.Result
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public T Data { get; }

        public bool IsSuccessed { get; }

        public bool IsShow { get; }

        public string Messages { get; }

        public DataResponse(T data,bool isSuccessed, bool isShow, string messages)
        {
            Data = data;
            IsSuccessed = isSuccessed;
            IsShow = isShow;
            Messages = messages;
        }
        public DataResponse(T data, bool isSuccessed, bool isShow)
        {
            Data = data;
            IsSuccessed = isSuccessed;
            IsShow = isShow;
        }
    }
}
