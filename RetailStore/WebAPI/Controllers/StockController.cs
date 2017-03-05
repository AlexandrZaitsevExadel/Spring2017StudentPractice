using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBase.Domain.Models;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebAPI.Controllers
{
    public class StockController : ApiController
    {
        static string connectionStringName = "WebAPI.Properties.Settings.ConnectionString";
        private Database _db = DatabaseFactory.CreateDatabase(connectionStringName);// Нормально ли здесь инстанциировать БД?
        [HttpGet]
        public List<AccessoryTable> GetAllAccessories() //В каком виде лучше возвращать данные? И IEnumerable и List -  браузер не воспринимает, а Postman нормально показывает.
        {

            return _db.ExecuteDataSet("spGetAccessoryRecords").Tables[0].AsEnumerable().Select(row => new AccessoryTable(Convert.ToInt32(row["AccessoryId"]), Convert.ToString(row["AccessoryName"]), Convert.ToInt32(row["Price"]))).ToList();

        }


        [HttpPost]
        public int AddAccessory(int id, string name, int price) //Что должны возвращать методы put, post, delete? 
        {
            return _db.ExecuteNonQuery("spInsertAccessory", new object[] { id, name, price });
        }

        [HttpDelete]
        public void DeleteAccessory(int id)
        {
            _db.ExecuteNonQuery("spDeleteAccessory", new object[] { id });
        }


        [HttpPut]
        public void UpdateAccessory(int id, string name, int price) //Не смог сделать так чтобы параметром была модель - не могу передать её как параметр по url-у, вылетает NullReferenceException, и в put и в post методах.
        {
            _db.ExecuteNonQuery("spUpdateAccessory", new object[] { id, name, price });
        }
    }
}
