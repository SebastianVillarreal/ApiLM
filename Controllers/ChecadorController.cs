using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiLM.DataContext;
using ApiLM.Models;

namespace ApiLM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecadorController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get(string codigo, int sucursal)
        {
            ChecadorDac dac = new ChecadorDac();
            Checador checador =  dac.GetPrecio(codigo, sucursal);
            
            return Ok(checador);
        }
    }
}