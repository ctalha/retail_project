using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Retail.Core.Performance
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PerformanceAttribute : Attribute
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAttribute(int interval)
        {
            _interval = interval;
            _stopwatch = new Stopwatch();
        }

        

    }
}
