using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSa.Library.Entities
{
    public class Employee
    {
        /// <summary>
        /// Id nhân viên 
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Code nhân viên 
        /// </summary>


        public string EmployeeCode { get; set; }
        /// <summary>
        /// Emial nhân viên 
        /// </summary>

        public string? Email { get; set; }
        /// <summary>
        /// Giới tính nhân viên 
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Họ và tên nhân viên 
        /// </summary> 
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        ///public string GenderName
        // {
        ///     get
        //   {
        ///     switch (Gender)
        //    {
        //      case 0:
        //       return "Nữ";
        //   case 1:
        //       return "Nam";
        //  default:
        //        return "không xác định";
        // }
        //   }
        //  }
    
}
}
