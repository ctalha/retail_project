using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Retail.Entities.Enums
{
    public enum DeliveryMode
    {
        [Description("Taşımalı")]
        Apartment = 1,
        [Description("Kapı Önü Teslim")]
        ApartmentFront = 2
    }
}
