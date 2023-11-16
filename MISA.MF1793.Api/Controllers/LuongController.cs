using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.MF1793.Api.Model;
using MySqlConnector;
using System.Xml.Linq;

namespace MISA.MF1793.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuongController<T> : ControllerBase
    {
      
        public LuongController()
        {
          
        }
        [HttpGet]
        public IActionResult Get()
        {
            

                return StatusCode(200);
            
           

        }
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            
            return StatusCode(201, 1);
        }
    }
}
