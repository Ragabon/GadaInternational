using AutoMapper;
using Gada.Api.Models;
using Gada.News.Entities;

namespace Gada.Api.AutoMappings
{
    public class NewsMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            Mapper.CreateMap<RssFeed, NewsListModel>()
                .ForMember(x => x.Title, src => src.MapFrom(x => x.Title))
                .ForMember(x => x.Description, src => src.MapFrom(x => x.Description))
                .ForMember(x => x.Link, src => src.MapFrom(x => x.Link))
                .ForMember(x => x.Thumbnail, src => src.MapFrom(x => x.Thumbnail))
                .IgnoreAllNonExisting();
        }
    }
}