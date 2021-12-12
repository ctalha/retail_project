using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.CustomExceptions
{
    public class BadRequestValidationResult
    {
        public string Description { get; set; }
        public int ErrorCode { get; set; }
        public IEnumerable<string> Message { get; set; }
    }
}
