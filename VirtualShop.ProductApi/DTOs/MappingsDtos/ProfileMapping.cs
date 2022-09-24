using AutoMapper;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.DTOs.MappingsDtos
{
    public class ProfileMapping:Profile
    {
        public ProfileMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>().ForMember(x => x.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
