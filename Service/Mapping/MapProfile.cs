using AutoMapper;
using Core.DTOs.Category;
using Core.DTOs.Customer;
using Core.DTOs.Product;
using Core.DTOs.Region;
using Core.DTOs.Shipper;
using Core.DTOs.Supplier;
using Core.DTOs.Territory;
using Core.Models;

namespace Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductListDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier));

            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<Supplier, SupplierCreateDto>().ReverseMap();
            CreateMap<SupplierUpdateDto, Supplier>();
            CreateMap<Supplier, SupplierListDto>();

            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Customer, CustomerListDto>();

            CreateMap<Shipper, ShipperCreateDto>().ReverseMap();
            CreateMap<ShipperUpdateDto, Shipper>();
            CreateMap<Shipper, ShipperListDto>();

            CreateMap<Region, RegionCreateDto>().ReverseMap();
            CreateMap<RegionUpdateDto, Region>();
            CreateMap<Region, RegionListDto>();

            CreateMap<Territory, TerritoryCreateDto>().ReverseMap();
            CreateMap<TerritoryUpdateDto, Territory>();
            CreateMap<Territory, TerritoryListDto>();
            CreateMap<Territory, TerritoryListDto>()
               .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region));
        }
    }
}
