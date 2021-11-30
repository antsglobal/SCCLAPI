using System;
using System.Collections.Generic;
using System.Text;
using IoTApi.Entities;
using System.Threading.Tasks;

namespace IoTApi.Business.IDeviceBo
{
    public interface IAssetBO
    {
        Task<EntitiesResult> Login(string strEmail, string strPassword);
        Task<AssetViewResultEntiriesDto> AssetView();
        Task<AssetRegisterResultEntiriesDto> AssetRegister(AssetEntitieseDto objAssetDto);
    }
}
