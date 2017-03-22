﻿using System;
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

        public int CreateAccessory(Accessory accessory)
        {
            return _db.ExecuteNonQuery("spInsertAccessory", new object[] { accessory.accessoryName, accessory.price });
        }

        public IList<Accessory> GetAccessories()
        {

            return _db.ExecuteDataSet("spGetAccessoryRecords").Tables[0].AsEnumerable().Select(row => new Accessory(Convert.ToInt32(row["AccessoryId"]), Convert.ToString(row["AccessoryName"]), Convert.ToInt32(row["Price"]))).ToList();;
        }

        public int UpdateAccessory(Accessory accessory)
        {

            return _db.ExecuteNonQuery("spUpdateAccessory", new object[] { accessory.accessoryId, accessory.accessoryName, accessory.price });
        }

        public int DeleteAccessory(int id)
        {

            return _db.ExecuteNonQuery("spDeleteAccessory", new object[] { id });
        }

        public IList<Purchase> GetPurchases()
        {
            return _db.ExecuteDataSet("spGetPurchaseRecords").Tables[0].AsEnumerable().Select(row => new Purchase(Convert.ToInt32(row["PurchaseId"]), Convert.ToInt32(row["AccessoryId"]), Convert.ToInt32(row["ClientId"]), Convert.ToInt32(row["Quantity"]), Convert.ToDateTime(row["PurchaseDate"]))).ToList();
        }

        public int CreatePurchase(StockPurchase stockPurchase)
        {
            return _db.ExecuteNonQuery("spInsertPurchase", new object[] { stockPurchase.accessoryId, stockPurchase.clientName, stockPurchase.quantity, DateTime.Now });
        }

        public int UpdatePurchase(Purchase purchase)
        {
            return _db.ExecuteNonQuery("spUpdatePurchase", new object[] { purchase.purchaseId, purchase.quantity });
        }

        public int DeletePurchase(int id)
        {
            return _db.ExecuteNonQuery("spDeletePurchase", new object[] { id });
        }
    }
}
