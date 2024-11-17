using EasyUrl.Services.Models;

namespace EasyUrl.Services.Mappers;

public static class EasyUrlMapper
{
    public static EasyUrlModel ToModel(this Persistent.Entities.EasyUrl easyUrl)
    {
        return new EasyUrlModel
        {
            Id = easyUrl.Id,
            OriginalUrl = easyUrl.OriginalUrl,
            ShortUrl = easyUrl.ShortUrl,
            CustomAlias = easyUrl.CustomAlias,
            CreatedDate = easyUrl.CreatedDate,
            ModifiedDate = easyUrl.ModifiedDate,
            DeletedDate = easyUrl.DeletedDate,
            ExpirationDate = easyUrl.ExpirationDate,
            IsDeleted = easyUrl.IsDeleted,
            CustomDomain = easyUrl.CustomDomain
        };
    }
    
    public static Persistent.Entities.EasyUrl ToEntity(this EasyUrlModel easyUrlModel)
    {
        return new Persistent.Entities.EasyUrl
        {
            OriginalUrl = easyUrlModel.OriginalUrl,
            ShortUrl = easyUrlModel.ShortUrl,
            CustomAlias = easyUrlModel.CustomAlias,
            ExpirationDate = easyUrlModel.ExpirationDate,
            IsDeleted = easyUrlModel.IsDeleted,
            CustomDomain = easyUrlModel.CustomDomain
        };
    }
}