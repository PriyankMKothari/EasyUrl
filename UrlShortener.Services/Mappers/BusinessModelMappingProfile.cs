using AutoMapper;
using UrlShortener.Persistent.Entities;
using UrlShortner.Services.Models;

namespace UrlShortener.Services.Mappers
{
    public sealed class BusinessModelMappingProfile : Profile
    {
        public BusinessModelMappingProfile()
        {
            CreateMap<TagModel, Tag>();
            CreateMap<Tag, TagModel>();
        }
    }
}
