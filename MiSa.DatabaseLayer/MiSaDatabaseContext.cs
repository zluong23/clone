using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;
using MiSa.DatabaseLayer.Interfaces;
using System.Resources;
using static Dapper.SqlMapper;
using MiSa.Library.Entities;

namespace MiSa.DatabaseLayer
{
  public class MiSaDatabaseContext<MiSaEntity>:IMiSaDatabaseContext
    {

        protected readonly string _connectionString = "Host=8.222.228.150;Port=3306;Database = misa.qlts_mf1726_ddhuy; User Id = nvmanh;Password = 12345678";
        protected MySqlConnection _connection;
        protected string _tableName;
        public MiSaDatabaseContext()
        {
            _tableName = typeof(MiSaEntity).Name;
            _connection = new MySqlConnection(_connectionString);
        }

      

        public List<T> GetAll<T>()
        {
            

                // Khởi tạo kết nôis với maria
                var sqlConnection = new MySqlConnection(_connectionString);
                // Lấy dữ liệu 
                // 1 Câu lệnh truy vấn lấy dữ liệu 
                var sql = $"SELECT * FROM {_tableName}";
                // 2 Thức hiện lấy dữ liệu 
                var employees = sqlConnection.Query<T>(sql);
                return employees.ToList();
            
           
        }

        public int Insert<T>(T entity)
        {
            var colNameList = ""; // EmployeeId,FullName....
            var colParamList = ""; // @EmployeeId,@FullName....


            // lay ra cac properties cua  cac doi tuong
            var props = typeof(T).GetProperties();
            // khai  bao param
            var parameters = new DynamicParameters();
            // duyet tung prop
            foreach (var prop in props)
            {
                // lay ten prop
                var propName = prop.Name;
                var value = prop.GetValue(entity);


                // lay value cua prop
                colNameList = colNameList + $"{propName},";
                colParamList = colParamList + $"@{propName},";
                parameters.Add($"@{propName}", value);

            }
            
            // bo dau , sau cung
            colNameList = colNameList.Substring(0, colNameList.Length - 1);
            colParamList = colParamList.Substring(0, colParamList.Length - 1);
            var sql = $"INSERT INTO {_tableName}({colNameList})VALUES({colParamList})";
            var res = _connection.Execute(sql, entity);
            return res;
        }
    }

       
    
}
