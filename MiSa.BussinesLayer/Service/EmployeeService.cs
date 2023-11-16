using MiSa.BussinesLayer.Interfaces;
using MiSa.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSa.BussinesLayer.Service
{
   public class EmployeeService : IEmployeeService
    {
        public bool InsertService(Employee employee)
        {
          
            if (!String.IsNullOrEmpty(employee.FullName))
            {
                employee.EmployeeId = Guid.NewGuid();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
