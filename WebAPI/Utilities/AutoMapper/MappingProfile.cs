using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;

namespace WebAPI.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductDetailsDto>();

            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<Category, CategoryDetailsDto>();

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
