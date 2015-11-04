using AutoMapper;
using Gada.Api.Models;
using Gada.Discussions.Entities;
using Gada.Api.Helpers;
using System.Linq;

namespace Gada.Api.AutoMappings
{
    public class PostsMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            Mapper.CreateMap<Post, LatestPostModel>()
                .ForMember(x => x.Post, src => src.MapFrom(x => x.Content))
                .ForMember(x => x.PostedBy, src => src.MapFrom(x => x.PostedBy.Username))
                .ForMember(x => x.Posted, src => src.MapFrom(x => DateTimeHelper.ConvertToRelativeTime(x.PostedOn)))
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Post, PostDetailModel>()
                .ForMember(x => x.Id, src => src.MapFrom(x => x.Id))
                .ForMember(x => x.Post, src => src.MapFrom(x => x.Content))
                .ForMember(x => x.PostedBy, src => src.MapFrom(x => x.PostedBy.Username))
                .ForMember(x => x.Posted, src => src.MapFrom(x => DateTimeHelper.ConvertToRelativeTime(x.PostedOn)))
                .ForMember(x => x.Votes, src => src.MapFrom(x => x.Votes))
                .IgnoreAllNonExisting();
        }
    }
}