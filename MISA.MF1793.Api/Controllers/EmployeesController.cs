using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiSa.BussinesLayer.Interfaces;
using MiSa.BussinesLayer.Service;
using MiSa.DatabaseLayer;
using MiSa.Library.Entities;
using MISA.MF1793.Api.Model;
using MySqlConnector;

namespace MISA.MF1793.Api.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            // gopi lay du lieu
            MiSaDatabaseContext<Employee> context = new MiSaDatabaseContext<Employee>();
            var employees = context.GetAll<Employee>();
            return StatusCode(200, employees);
        }
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            try
            {
                //  xu li nghiep vu ket qua
                EmployeeService service = new EmployeeService();
                var serviiceResult = service.InsertService(employee);

                if (serviiceResult == true)
                {
                    MiSaDatabaseContext<Employee> context = new MiSaDatabaseContext<Employee>();                
                    var res = context.Insert(employee);
                    return StatusCode(201, res);

                }
                else
                {
                    var res = new
                    {
                        DevMsg = " khong hop le",
                    };
                    return StatusCode(400, res);
                }
            }catch (Exception ex)
            {
                return HandleException(ex);
            }
            


        }
        ///Hàm khai báo lỗi 500
        private IActionResult HandleException(Exception ex)
        {
            var error = new ErrorService();
            error.DevMsg = ex.Message;
            error.UserMsg = Resources.ResourceVN.Error_Exception;
            return StatusCode(500, error);
        }
    }



}
