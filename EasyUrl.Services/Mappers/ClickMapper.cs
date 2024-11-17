using EasyUrl.Services.Models;

namespace EasyUrl.Services.Mappers;

public static class ClickMapper
{
    public static ClickModel ToModel(this Persistent.Entities.Click click)
    {
        return new ClickModel
        {
            Id = click.Id,
            IpAddress = click.IpAddress,
            UserAgent = click.UserAgent,
            DeviceType = click.DeviceType,
            Browser = click.Browser,
            Country = click.Country,
            CreatedAt = click.CreatedAt,
            EasyUrlModel = click.EasyUrl.ToModel()
        };
    }
    
    public static Persistent.Entities.Click ToEntity(this ClickModel clickModel)
    {
        return new Persistent.Entities.Click
        {
            IpAddress = clickModel.IpAddress,
            UserAgent = clickModel.UserAgent,
            DeviceType = clickModel.DeviceType,
            Browser = clickModel.Browser,
            Country = clickModel.Country
        };
    }
}