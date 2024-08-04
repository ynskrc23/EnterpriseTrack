using AutoMapper;
using Core.DTOs.Category;
using Core.DTOs.Product;
using Core.DTOs.Supplier;
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

            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<Supplier, SupplierCreateDto>().ReverseMap();
            CreateMap<SupplierUpdateDto, Supplier>();
            CreateMap<Supplier, SupplierListDto>();
        }
    }
}
