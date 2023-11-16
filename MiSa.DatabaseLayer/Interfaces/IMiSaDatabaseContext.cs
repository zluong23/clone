using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSa.DatabaseLayer.Interfaces
{
    public interface IMiSaDatabaseContext
    {
        List<T> GetAll<T>();
        int  Insert<T>(T  item);

       // int Update<T>(T item);
       // int Delete<T>(T item);
    }
}
