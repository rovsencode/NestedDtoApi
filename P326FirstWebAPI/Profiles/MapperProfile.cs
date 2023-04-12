using AutoMapper;
using P326FirstWebAPI.Dtos.CategoryDto;
using P326FirstWebAPI.Dtos.ProductDtos;
using P326FirstWebAPI.Extentions;
using P326FirstWebAPI.Models;

namespace P326FirstWebAPI.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryReturnDto>()
                .ForMember(d => d.ImageUrl, map => map.MapFrom(src => "https://localhost:7076/img/" + src.ImageUrl))
                .ForMember(d => d.CreateAge, map => map.MapFrom(src => src.CreatedTime.CalculateAge()));
            CreateMap<Category,CategoryInProductReturnDto>().ReverseMap();
            CreateMap<Product, ProductReturnDto>()
                .ForMember(d => d.Profit, map => map.MapFrom(src => src.SalePrice - src.CostPrice));

        }

    }
}
