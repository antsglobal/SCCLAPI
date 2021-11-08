using System;
using System.Collections.Generic;
using System.Text;
using IoTApi.Entities;
using System.Threading.Tasks;

namespace IoTApi.Data.IDeviceDac
{
    interface IAssetDAC
    {
        Task<UserDto> Login(string strEmail, string strPassword);
    }
}
