using AutoMapper;
using EasyUrl.Persistent.Entities;
using EasyUrl.Services.Models;

namespace EasyUrl.Services.Mappers;

public sealed class BusinessModelMappingProfile : Profile
{
    public BusinessModelMappingProfile()
    {
        CreateMap<TagModel, Tag>();
        CreateMap<Tag, TagModel>();
    }
}