using AutoMapper;
using Gada.Api.Models;
using Gada.Skills.Entities;

namespace Gada.Api.AutoMappings
{
    public class SkillsMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            Mapper.CreateMap<Skill, SkillsModel>()
                .ForMember(x => x.Skill, src => src.MapFrom(x => x.Title))
                .IgnoreAllNonExisting();

        }
    }
}