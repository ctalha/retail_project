using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Retail.Entities.Enums
{
    public enum Situation
    {
        [Description("Teklif")]
        Offer = 1,
        [Description("Beklemede")]
        OnHold = 2,
        [Description("Hazırlanıyor")]
        Prepare = 3,
        [Description("Bitti")]
        Finished = 4,
        [Description("Teslim Edildi")]
        Delivered = 5
    }
}
