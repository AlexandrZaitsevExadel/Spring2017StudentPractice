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
           _db = DatabaseFactory.CreateDatabase(connectionStringName);
        }

        public int Create(Accessory accessory)
        {
            return _db.ExecuteNonQuery("spInsertAccessory", new object[] { accessory.accessoryName, accessory.price });
        }

        public IList<Accessory> Read()
        {

            return _db.ExecuteDataSet("spGetAccessoryRecords").Tables[0].AsEnumerable().Select(row => new Accessory(Convert.ToInt32(row["AccessoryId"]), Convert.ToString(row["AccessoryName"]), Convert.ToInt32(row["Price"]))).ToList();;
        }

        public void Update(Accessory accessory)
        {

            _db.ExecuteNonQuery("spUpdateAccessory", new object[] { accessory.accessoryId, accessory.accessoryName, accessory.price });
        }

        public void Delete(int id)
        {

            _db.ExecuteNonQuery("spDeleteAccessory", new object[] { id });
        }
    }
}
