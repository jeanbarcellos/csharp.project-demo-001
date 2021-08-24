using AutoMapper;
using Demo.Api.ViewModel;
using Demo.Domain.Entities;

namespace Demo.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryViewModel, Category>();
        }
    }
}
