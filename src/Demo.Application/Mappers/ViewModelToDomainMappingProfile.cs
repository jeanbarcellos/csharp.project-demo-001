using AutoMapper;
using Demo.Application.ViewModel;
using Demo.Domain.Entities;

namespace Demo.Application.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryViewModel, Category>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
