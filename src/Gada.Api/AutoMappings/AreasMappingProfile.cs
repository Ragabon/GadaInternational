using AutoMapper;
using Gada.Api.Models;
using Gada.Discussions.Entities;
using Gada.Api.Helpers;
using System.Linq;

namespace Gada.Api.AutoMappings
{
    public class AreasMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            Mapper.CreateMap<Area, AreasModel>()
                .ForMember(x => x.Id, src => src.MapFrom(x => x.Id))
                .ForMember(x => x.Title, src => src.MapFrom(x => x.Title))
                .ForMember(x => x.Description, src => src.MapFrom(x => x.Description))
                .ForMember(x => x.Icon, src => src.MapFrom(x => x.Icon))
                .IgnoreAllNonExisting();
        }
    }
}