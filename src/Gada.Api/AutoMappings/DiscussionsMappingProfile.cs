using System.Collections.Generic;
using AutoMapper;
using Gada.Api.Models;
using Gada.Discussions.Entities;
using Gada.Api.Helpers;
using System.Linq;

namespace Gada.Api.AutoMappings
{
    public class DiscussionsMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            Mapper.CreateMap<Discussion, DiscussionListModel>()
                .ForMember(x => x.Id, src => src.MapFrom(x => x.Id))
                .ForMember(x => x.Title, src => src.MapFrom(x => x.Title))
                .ForMember(x => x.Description, src => src.MapFrom(x => StringHelper.TruncateAtWord(x.Description, 250)))
                .ForMember(x => x.CreatedBy, src => src.MapFrom(x => x.CreatedBy.Username))
                .ForMember(x => x.Created, src => src.MapFrom(x => DateTimeHelper.ConvertToRelativeTime(x.CreatedOn)))
                .ForMember(x => x.Votes, src => src.MapFrom(x => x.Votes))
                .ForMember(x => x.Views, src => src.MapFrom(x => x.Views))
                .ForMember(x => x.Posts, src => src.MapFrom(x => x.PostCount))
                .ForMember(x => x.Interests, src => src.MapFrom(x => x.Interests.Select(c => c.Title).ToList()))
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Discussion, DiscussionDetailModel>()
                .ForMember(x => x.Id, src => src.MapFrom(x => x.Id))
                .ForMember(x => x.Title, src => src.MapFrom(x => x.Title))
                .ForMember(x => x.Description, src => src.MapFrom(x => x.Description))
                .ForMember(x => x.CreatedBy, src => src.MapFrom(x => x.CreatedBy.Username))
                .ForMember(x => x.Created, src => src.MapFrom(x => DateTimeHelper.ConvertToRelativeTime(x.CreatedOn)))
                .ForMember(x => x.Votes, src => src.MapFrom(x => x.Votes))
                .ForMember(x => x.Views, src => src.MapFrom(x => x.Views))
                .ForMember(x => x.Interests, src => src.MapFrom(x => x.Interests.Select(c => c.Title).ToList()))
                .ForMember(x => x.Posts, src => src.MapFrom(x => Mapper.Map<List<Post>, List<PostDetailModel>>(x.Posts)))
                .IgnoreAllNonExisting();
        }
    }
}