using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Zhaoxi.WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //dotnet Zhaoxi.WebApiDemo.dll --urls="http://*:5726" --ip="192.168.15.15" --port=5726
        //dotnet Zhaoxi.WebApiDemo.dll --urls="http://*:5727" --ip="192.168.15.15" --port=5727
        //dotnet Zhaoxi.WebApiDemo.dll --urls="http://*:5728" --ip="192.168.15.15" --port=5728

        private readonly  ILogger<UsersController> _logger = null;
        private readonly IConfiguration _iConfiguration = null;

        public UsersController(ILogger<UsersController> logger, IConfiguration iConfiguration)
        {
            this._logger = logger;
            this._iConfiguration = iConfiguration;
        }

        //GET:API/<CONTROLLER>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", this._iConfiguration["ip"], this._iConfiguration["port"] };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"{id}_{this._iConfiguration["ip"]}:{this._iConfiguration["port"]}";
        }

    }
}
