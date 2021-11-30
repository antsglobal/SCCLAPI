using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using IoTApi.Business.IDeviceBo;
using IoTApi.Business.DeviceBo;
using IoTApi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IoTApi.Controllers
{
    [ApiController]
    [Route("assets/api/[action]")]
    
    public class AssetController : ControllerBase
    {
        private IAssetBO _objAssetBO;
        UserDto objUser;
        public AssetController(IAssetBO objAssetBO)
        {
            this._objAssetBO = objAssetBO;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            try
            {
                return Ok("Server is up and running");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string userEmail, [FromForm] string userPassword)
        {
            object obj = new object();
            try
            {
                 
                return Ok(await this._objAssetBO.Login(userEmail, userPassword));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> assetview()
        {
            object obj = new object();
            try
            {

                return Ok(await this._objAssetBO.AssetView());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssetRegister([FromForm] AssetEntitieseDto objAssetsView)
        {
            object obj = new object();
            try
            {

                return Ok(await this._objAssetBO.AssetRegister(objAssetsView));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
