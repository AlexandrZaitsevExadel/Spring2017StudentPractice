using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DBase.Domain.Models;

namespace DBase.Domain.Services
{
    public class StockService : IStoreService
    {

        private Database _db;

        public StockService(string connectionStringName)
        {
            Database db = DatabaseFactory.CreateDatabase(connectionStringName);
            this._db = db;
        }

        public int Create(AccessoryTable accessoryTable)
        {
            return _db.ExecuteNonQuery("spInsertAccessory", new object[] { accessoryTable.accessoryId, accessoryTable.accessoryName, accessoryTable.price });
        }

        public DataSet Read()
        {

            return _db.ExecuteDataSet("spGetAccessoryRecords");
        }

        public void Update(AccessoryTable accessoryTable)
        {

            _db.ExecuteNonQuery("spUpdateAccessory", new object[] { accessoryTable.accessoryId, accessoryTable.accessoryName, accessoryTable.price });
        }

        public void Delete(int id)
        {

            _db.ExecuteNonQuery("spDeleteAccessory", new object[] { id });
        }
    }
}
