using AutoMapper;
using Demo.Api.ViewModel;
using Demo.Domain.Entities;

namespace Demo.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
