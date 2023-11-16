using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using MISA.MF1793.Api.Model;
using Microsoft.Extensions.Caching.Memory;

namespace MISA.MF1793.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 200 - Danh sách khách hàng 
        /// 204 - Không có dữ liệu
        /// </returns>
        /// CreateBy: pvluong
        [HttpGet()]
       
        public IActionResult Get()
        {
            // Khai báo  thông tin kết nối 
            var connectionString = "Host=18.179.16.166;Port=3306;Database = misa.qlts_mf1726_ddhuy; User Id = nvmanh;Password = 12345678";
            // Khởi tạo kết nôis với maria
            var sqlConnection = new MySqlConnection(connectionString);
            // Lấy dữ liệu 
            // 1 Câu lệnh truy vấn lấy dữ liệu 
            var sql = "SELECT * FROM Customer";
            // 2 Thức hiện lấy dữ liệu 
            var customers = sqlConnection.Query<Customer>(sql);
            return Ok(customers);
        }
        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
        {
            // Khai báo  thông tin kết nối 
            var connectionString = "Host=18.179.16.166;Port=3306;Database = WEB081_MF1793_PVLUONG; User Id = nvmanh;Password = 12345678";
            // Khởi tạo kết nôis với maria
            var sqlConnection = new MySqlConnection(connectionString);
            // Lấy dữ liệu 
            // 1 Câu lệnh truy vấn lấy dữ liệu 
            // Lưu ý có tham số truyền vào thì phải có DynamicParameter 
            var sqlCommand = $"SELECT * FROM Customer WHERE CustomerId = @CustomerId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", customerId);
            // 2 Thức hiện lấy dữ liệu 
            var customers = sqlConnection.QueryFirstOrDefault<Customer>(sql: sqlCommand, param: parameters);
            return StatusCode(201, customers);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
        

            var connectionString = "Host=18.179.16.166;Port=3306;Database=WEB081_MF1793_PVLUONG;User Id=nvmanh;Password=12345678";

            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                var sql = "INSERT INTO Customer (CustomerId, FullName) VALUES (@CustomerId, @FullName)";

                var parameters = new
                {
                    CustomerId = Guid.NewGuid(),
                    FullName = customer.FullName
                };

                var affectedRows = sqlConnection.Execute(sql, parameters);

                if (affectedRows > 0)
                {
                    return StatusCode(201, "Thêm mới khách hàng thành công");
                }
                else
                {
                    return StatusCode(500, "Lỗi khi thêm mới khách hàng");
                }
            }
        }
        /// <summary>
        /// ////////////////
        /// </summary>

        [HttpPut("{customerId}")]
        public IActionResult Put(Guid customerId, [FromBody] Customer updatedCustomer)
        {
            // Validate if the customerId and updatedCustomer are provided
           

            // Khai báo thông tin kết nối 
            var connectionString = "Host=18.179.16.166;Port=3306;Database=WEB081_MF1793_PVLUONG;User Id=nvmanh;Password=12345678";
            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                // Lấy dữ liệu từ database để kiểm tra sự tồn tại của khách hàng
                var existingCustomer = sqlConnection.QueryFirstOrDefault<Customer>("SELECT * FROM Customer WHERE CustomerId = @CustomerId", new { CustomerId = customerId });

                if (existingCustomer == null)
                {
                    return StatusCode(404, "Không tìm thấy khách hàng.");
                }

                // Cập nhật thông tin khách hàng
                existingCustomer.FullName = updatedCustomer.FullName;
                existingCustomer.Email = updatedCustomer.Email;
                // Cập nhật các trường thông tin khác tương tự...

                // Câu lệnh SQL UPDATE
                var sql = "UPDATE Customer SET FullName = @FullName, Email = @Email WHERE CustomerId = @CustomerId";
                var rowsAffected = sqlConnection.Execute(sql, existingCustomer);

                if (rowsAffected > 0)
                {
                    return StatusCode(201, "Cập nhật khách hàng thành công.");
                }
                else
                {
                    return StatusCode(500, "Lỗi khi cập nhật khách hàng.");
                }
            }
        }
        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            // Validate if the customerId is provided
            if (customerId == Guid.Empty)
            {
                var res = new
                {
                    devMsg = "CustomerId is required.",
                    userMsg = "CustomerId không được để trống.",
                    data = "data"
                };
                return StatusCode(400, res);
            }

            // Khai báo thông tin kết nối 
            var connectionString = "Host=18.179.16.166;Port=3306;Database=WEB081_MF1793_PVLUONG;User Id=nvmanh;Password=12345678";
            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                // Lấy dữ liệu từ database để kiểm tra sự tồn tại của khách hàng
                var existingCustomer = sqlConnection.QueryFirstOrDefault<Customer>("SELECT * FROM Customer WHERE CustomerId = @CustomerId", new { CustomerId = customerId });

                if (existingCustomer == null)
                {
                    return StatusCode(404, "Không tìm thấy khách hàng.");
                }

                // Câu lệnh SQL DELETE
                var sql = "DELETE FROM Customer WHERE CustomerId = @CustomerId";
                var rowsAffected = sqlConnection.Execute(sql, new { CustomerId = customerId });

                if (rowsAffected > 0)
                {
                    return StatusCode(201, "Xóa khách hàng thành công.");
                }
                else
                {
                    return StatusCode(500, "Lỗi khi xóa khách hàng.");
                }
            }
        }
    }

    }
