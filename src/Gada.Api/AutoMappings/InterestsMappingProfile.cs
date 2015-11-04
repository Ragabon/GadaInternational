using AutoMapper;
using Gada.Api.Models;
using Gada.Interests.Entities;

namespace Gada.Api.AutoMappings
{
    public class InterestsMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            Mapper.CreateMap<Interest, InterestsModel>()
                .ForMember(x => x.Interest, src => src.MapFrom(x => x.Title))
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Interest, Gada.Discussions.Entities.Interest>()
                .ForMember(x => x.Id, src => src.MapFrom(x => x.Id))
                .ForMember(x => x.Title, src => src.MapFrom(x => x.Title))
                .IgnoreAllNonExisting();
        }
    }
}