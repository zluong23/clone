using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;
using MiSa.Library.Entities;

namespace MiSa.BussinesLayer.Interfaces
{
   public interface IEmployeeService
    {
        bool InsertService(Employee employee);
    }
}
