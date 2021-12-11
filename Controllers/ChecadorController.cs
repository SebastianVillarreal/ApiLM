using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiLM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecadorController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            ConexionDataAccess dac = new ConexionDataAccess();
            return "sebas";
        }
    }
}