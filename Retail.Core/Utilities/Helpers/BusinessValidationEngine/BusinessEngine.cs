using Retail.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Core.Utilities.Helpers.BusinessValidationEngine
{
    public static class BusinessEngine
    {
        
        public static IResponse Run(params IResponse[] methods)
        {

            foreach (var method in methods)
            {
                if (method.IsSuccessed == false)
                {
                    return method;
                }
            }
            return null;
        }
    }
}
