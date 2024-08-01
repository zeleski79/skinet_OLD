using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // AutoMapper will try to copy the data from Product 
            // to ProductToReturnDto using the property names and types
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(destination => destination.ProductBrand, x => x.MapFrom(source => source.ProductBrand.Name ))
                .ForMember(destination => destination.ProductType, x => x.MapFrom(source => source.ProductType.Name ))
                .ForMember(destination => destination.PictureUrl, x => x.MapFrom<ProductUrlResolver>());
        }
    }
}