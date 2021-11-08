using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTApi.Controllers
{
    [ApiController]
    [Route("sccl/api/[action]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "return from Get";
        }

        [HttpPost]
        public string Login(string strEmail, string strPass)
        {
            return "return from Get1" + strEmail;
        }
    }
}
