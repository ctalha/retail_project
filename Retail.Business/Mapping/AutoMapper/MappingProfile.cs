using AutoMapper;
using Retail.Entities.Dtos;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Mapping.AutoMapper
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDetailDto, Order>().ReverseMap();
            CreateMap<OrderDetailDto, Product>().ReverseMap();
            CreateMap<OrderDetailDto, Customer>().ReverseMap();
            CreateMap<OrderDetailDto, AfterSale>().ReverseMap();
        }
    }
}
