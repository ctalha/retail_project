using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.Utilities.Result
{
    public interface IDataResponse<T> : IResponse
    {
        public T Data { get; }

    }
}
