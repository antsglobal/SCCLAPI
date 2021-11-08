using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Linq;
using Dapper;
using IoTApi.Entities;
using System.Linq.Expressions;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;

namespace IoTApi.Data.DeviceDac
{
    class AssetDAC : BaseDac
    {

        
        public async Task<UserDto> Login(string strEmail, string strPassword)
        {
            string strGetUserDetails = "select * from User_Details where Email='" + strEmail + "'";
            UserDto objUserDto;
            using (var conn = base.ObjConnection)
            {

                objUserDto = (await conn.QueryAsync<UserDto>("strGetUserDetails", commandTimeout: 120, commandType: CommandType.Text)).FirstOrDefault();
            }
            return objUserDto;

        }
    }
}
