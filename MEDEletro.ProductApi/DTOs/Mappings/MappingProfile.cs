using AutoMapper;
using MEDEletro.ProductApi.Models;

namespace MEDEletro.ProductApi.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();  
        }
    }
}
