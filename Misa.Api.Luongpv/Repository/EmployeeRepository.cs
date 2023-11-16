using MiSa.Core.Luongpv.Entities;
using MiSa.Core.Luongpv.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;

namespace Misa.InfrastuctureLuongpv.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public int Delete(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            // Khai báo  thông tin kết nối 
            var connectionString = "Host=18.179.16.166;Port=3306;Database = WEB081_MF1793_PVLUONG; User Id = nvmanh;Password = 12345678";
            // Khởi tạo kết nôis với maria
            var sqlConnection = new MySqlConnection(connectionString);
            // Lấy dữ liệu 
            // 1 Câu lệnh truy vấn lấy dữ liệu 
            var sql = "SELECT * FROM Employee";
            // 2 Thức hiện lấy dữ liệu 
            var employees = sqlConnection.Query<Employee>(sql);
            return employees;
        }

        public Employee GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetPaging(int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        public int Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee employee, Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
