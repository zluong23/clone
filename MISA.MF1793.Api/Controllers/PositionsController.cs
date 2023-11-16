using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.MF1793.Api.Model;
using MySqlConnector;
using System.Security.Cryptography.X509Certificates;

namespace MISA.MF1793.Api.Controllers
{
    [Route("api/v1/Positions")]
    [ApiController]
    public class PositionsController : LuongController<Position>
    {
    
    }
}
