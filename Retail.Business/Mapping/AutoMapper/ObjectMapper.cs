using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Mapping.AutoMapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() => 
        {

                var config = new MapperConfiguration(cfg =>
                {
                    // Add all profiles in current assembly
                    cfg.AddProfile(new MappingProfile());
                });

                return config.CreateMapper();

        });

        public static IMapper Mapper => lazy.Value;
    }
}
