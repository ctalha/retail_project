using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.Utilities.Result
{
    public interface IResponse
    {
        public bool IsSuccessed { get;  }
        public bool IsShow { get; }
        public string Messages { get; }
    }
}
