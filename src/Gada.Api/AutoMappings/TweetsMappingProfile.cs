using AutoMapper;
using Gada.Api.Models;
using Gada.Twitter.Entities;

namespace Gada.Api.AutoMappings
{
    public class TweetsMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            Mapper.CreateMap<Tweet, TweetsModel>()
                .ForMember(x => x.ImageUrl, src => src.MapFrom(x => x.ImageUrl))
                .ForMember(x => x.ScreenName, src => src.MapFrom(x => x.ScreenName))
                .ForMember(x => x.MediaUrl, src => src.MapFrom(x => x.MediaUrl))
                .ForMember(x => x.Tweet, src => src.MapFrom(x => x.Content))
                .IgnoreAllNonExisting();
        }
    }
}