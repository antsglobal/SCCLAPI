using System;
using System.Collections.Generic;
using System.Text;
using IoTApi.Business.IDeviceBo;
using IoTApi.Entities;
using IoTApi.Data.IDeviceDac;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Globalization;
using System.Reflection;
using IoTApi.Data;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace IoTApi.Business.DeviceBo
{
    public class AssetsBO: BaseDac, IAssetBO
    {
        private IAssetBO objAssetBO;
        

        public async Task<EntitiesResult> Login( string strEmail, string strPassword)
        {
            EntitiesResult entitiesResult;
            entitiesResult = await this.getUserDetails(strEmail, strPassword);

            return entitiesResult;
        }

        public async Task<AssetViewResultEntiriesDto> AssetView()
        {
            AssetViewResultEntiriesDto objAssetsResult;
            objAssetsResult = await this.getAssetDetails();

            return objAssetsResult;
        }

        public async Task<AssetRegisterResultEntiriesDto> AssetRegister(AssetEntitieseDto objAssetsDto)
        {
            AssetRegisterResultEntiriesDto objAssetsResult;
            objAssetsResult = await this.insertAssetDetails(objAssetsDto);

            return objAssetsResult;
        }


        public async Task<EntitiesResult> getUserDetails(string strEmail, string strPassword)
        {
            //string hashedPass = MD5Hash(strPassword);
            //string strGetUserDetails = "select [User_Id], [User_Name], [User_Email],  '******' as [User_Password], Is_Active from User_Details where User_Email='" + strEmail + "' and User_Password='" + hashedPass + "'";
            string strGetUserDetails = "select [User_Id], [User_Name], [User_Email],  '******' as [User_Password], Is_Active from User_Details where User_Email='" + strEmail + "' and User_Password='" + strPassword + "'";
            UserDto objUserDto;
            UserLoginDto userLoginDto = new UserLoginDto();

            try
            {
                using (var conn = base.ObjConnection)
                {

                    objUserDto = (await conn.QueryAsync<UserDto>(strGetUserDetails, commandTimeout: 120, commandType: CommandType.Text)).FirstOrDefault();

                    userLoginDto.userId = objUserDto.User_Id;
                    //userLoginDto.userId = objUserDto.User_Id;
                    userLoginDto.userName = objUserDto.User_Name;
                    userLoginDto.userEmail = objUserDto.User_Email;
                    userLoginDto.userPassword = objUserDto.User_Password;
                    userLoginDto.isActive = objUserDto.Is_Active;

                }
                if( objUserDto == null )
                {
                    return new EntitiesResult() { status = "false", message = "Invalid user name or password", data = null };
                }
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return new EntitiesResult() { status = "false", message = "Login error", data = null };
            }
            return new EntitiesResult() { status = "true", message = "Login Success", data = userLoginDto };
            //return objUserDto;

        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public async Task<AssetViewResultEntiriesDto> getAssetDetails()
        {
            string strAssetView = "select * from AssetDetails";
            IEnumerable<AssetEntitieseDto> objAssetDto;
            //AssetViewResultEntiriesDto objAssetResultDto;

            try
            {
                using (var conn = base.ObjConnection)
                {

                    objAssetDto =  (await conn.QueryAsync<AssetEntitieseDto>(strAssetView, commandTimeout: 120, commandType: CommandType.Text));

                }
                if (objAssetDto == null)
                {
                    return new AssetViewResultEntiriesDto() { status = "false", message = "No Data in Assets", data = null };
                }
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return new AssetViewResultEntiriesDto() { status = "false", message = "Error in AssetsView", data = null };
            }
            return new AssetViewResultEntiriesDto() { status = "true", message = "asset details added successfully", data = objAssetDto };
            
        }
        string strAssetView = "insert into AssetDetails(AssetCode, AssetDescription, Location, Status, Action) values(@assetCode, @assetDescription, @Location, @status, @action)";
        public async Task<AssetRegisterResultEntiriesDto> insertAssetDetails(AssetEntitieseDto objAssetsDto)
        {
            AssetEntitieseDto objAssetDto;
            AssetRegisterResultEntiriesDto objAssetResultDto;
            objAssetDto = objAssetsDto;
           
            int result = 0;
            
            try
            {
                using (var conn = base.ObjConnection)
                {

                    //assetEntitieseDtos = (await conn.QueryAsync<AssetEntitieseDto>(strAssetView, commandTimeout: 120, commandType: CommandType.Text));

                    result = Convert.ToInt32(conn.ExecuteScalar(strAssetView,
                                                            commandTimeout: 120,
                                                             param: new
                                                             {
                                                                 @assetCode = objAssetsDto.AssetCode,
                                                                 @assetDescription = objAssetsDto.AssetDescription,
                                                                 @Location = objAssetsDto.Location,
                                                                 @status = objAssetsDto.status,
                                                                 @action = 1
                                                             }));

                }
                if (result == 0)
                {
                    return new AssetRegisterResultEntiriesDto() { status = "false", message = "No Data in Assets", data = 0 };
                }
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                string strException = ex.ToString();
                return new AssetRegisterResultEntiriesDto() { status = "false", message = "Error in registering asset", data = 0 };
            }
            return new AssetRegisterResultEntiriesDto() { status = "true", message = "asset details added successfully", data = result };

        }

    }
}
