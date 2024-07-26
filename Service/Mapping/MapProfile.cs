using AutoMapper;
using Core.DTOs.Product;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductListDto>();
        }
    }
}
