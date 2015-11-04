using System;
using AutoMapper;
using Gada.Api.Helpers;
using Gada.Api.Models;
using Gada.Discussions.Entities;

namespace Gada.Api.AutoMappings
{
    public class HomeMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            Mapper.CreateMap<Discussion, NewsFeedModel>()
                .ForMember(x => x.CreatedBy, src => src.MapFrom(x => x.CreatedBy.Username))
                .ForMember(x => x.CreatedDateTime, src => src.MapFrom(x => x.CreatedOn))
                .ForMember(x => x.CreatedOnRelativeTime, src => src.MapFrom(x => DateTimeHelper.ConvertToRelativeTime(x.CreatedOn)))
                .ForMember(x => x.Event, src => src.MapFrom(x => String.Format("started a discussion <a href='#discussions/{0}'>{1}</a>", x.Id, x.Title)))
                .ForMember(x => x.Content, src => src.MapFrom(x => x.Description))
                .ForMember(x => x.UpdateId, src => src.MapFrom(x => x.Id))
                .ForMember(x => x.UpdateType, src => src.UseValue(UpdateType.Discussion))
                .IgnoreAllNonExisting();

            Mapper.CreateMap<Post, NewsFeedModel>()
                .ForMember(x => x.CreatedBy, src => src.MapFrom(x => x.PostedBy.Username))
                .ForMember(x => x.CreatedDateTime, src => src.MapFrom(x => x.PostedOn))
                .ForMember(x => x.CreatedOnRelativeTime, src => src.MapFrom(x => DateTimeHelper.ConvertToRelativeTime(x.PostedOn)))
                .ForMember(x => x.Event, src => src.MapFrom(x => String.Format("posted on <a href='#discussions/{0}'>{1}</a>", x.Discussion.Id, x.Discussion.Title)))
                .ForMember(x => x.Content, src => src.MapFrom(x => x.Content))
                .ForMember(x => x.UpdateId, src => src.MapFrom(x => x.Discussion.Id))
                .ForMember(x => x.UpdateType, src => src.UseValue(UpdateType.Discussion))
                .IgnoreAllNonExisting();
        }
    }
}