using AutoMapper;
using EasyUrl.Persistent.Entities;
using UrlShortener.Services.Models;

namespace UrlShortener.Services.Mappers;

public sealed class BusinessModelMappingProfile : Profile
{
    public BusinessModelMappingProfile()
    {
        CreateMap<TagModel, Tag>();
        CreateMap<Tag, TagModel>();
    }
}