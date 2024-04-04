using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Data
{
    public interface IDataHelper<Table>
    {
        // Read

        List<Table> GetAllData();
        List<Table> Search(string searchIteam);
        Table Find(int Id);

        // Write

        int Add(Table table);   
        int Update(Table table);
        int Delete(int Id);
    }
}
