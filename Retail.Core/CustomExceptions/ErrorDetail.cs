using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace Retail.Core.CustomExceptions
{

    public class ErrorDetail 
    {
        public int StatusCode { get; set; }
        public string Messages { get; set; }
    }
}
