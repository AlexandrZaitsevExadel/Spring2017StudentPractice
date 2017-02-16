using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DBase.Domain.Services
{
    public class StockService : CRUD
    {

        public void create(Database db, int id, string name, int price)
        {
            db.ExecuteNonQuery("spInsertAccessory", new object[] {id, name, price });
        }

        public DataSet read(Database db)
        {

            return db.ExecuteDataSet("spGetAccessoryRecords");
        }

        public void update(Database db, int id, string name, int price)
        {

            db.ExecuteNonQuery("spUpdateAccessory", new object[] { id, name, price });
        }

        public void delete(Database db, int id)
        {

            db.ExecuteNonQuery("spDeleteAccessory", new object[] { id });
        }
    }
}
