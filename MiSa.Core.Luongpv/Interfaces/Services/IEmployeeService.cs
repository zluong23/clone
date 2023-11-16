using MiSa.Core.Luongpv.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSa.Core.Luongpv.Interfaces.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Thêm mới  dữ liệu 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreateBy : pvluong
        int InsertService(Employee employee);
        /// <summary>
        /// cập nhật duwx liệu  
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreateBy : pvluong
        int UpdateService (Employee employee,Guid employeeId);
    }
}
