using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.InfrastuctureLuongpv.Repository;
using MiSa.Core.Luongpv.Entities;
using MiSa.Core.Luongpv.Services;

namespace Misa.WebApi.Luongpv.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get()
        {
            // ket noi  database
            EmployeeRepository employeeRepository = new EmployeeRepository();
            var employee = employeeRepository.GetAll();
            return Ok(employee);
            // thuc hien lay du lieu 

           
        }
        [HttpGet("{employeeId}")]
        public IActionResult GetById(Guid employeeId)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            var employee = employeeRepository.GetById(employeeId);
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            // validate
           EmployeeServicecs employeeServicecs = new EmployeeServicecs();
            var res = employeeServicecs.InsertService(employee);
            // them moi vao database 
            return Ok(employee);
        }
        [HttpPut]
        public IActionResult Put(Employee employee,Guid employeeId)
        {
            return Ok();
        }
        [HttpDelete("employeeId")]
        public IActionResult Deletet(Guid employeeId)
        {
            return Ok();
        }
    }
}
