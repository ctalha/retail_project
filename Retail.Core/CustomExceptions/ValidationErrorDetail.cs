using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.CustomExceptions
{
    public class ValidationErrorDetail
    {
        public int StatusCode { get; set; }
        public string Messages { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
