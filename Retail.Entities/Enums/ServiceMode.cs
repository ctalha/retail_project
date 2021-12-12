using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Entities.Enums
{
    public enum ServiceMode
    {
        [Description("Kurulumlu")]
        Setup = 1,
        [Description("Kurulumlumsuz")]
        NonSetup = 2
    }
}
