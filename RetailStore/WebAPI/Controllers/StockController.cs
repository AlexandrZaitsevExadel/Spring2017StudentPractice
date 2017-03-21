using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DBase.Domain.Models;
using System.Web.Script.Serialization;
using DBase.Domain.Services;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    public class StockController : ApiController
    {
        
        private Database _db;
        
        public StockController()
        {
            _db = DatabaseFactory.CreateDatabase("WebAPI.Properties.Settings.ConnectionString");
        }

        [HttpGet]
        [Route("api/accessories")]
        public IList<Accessory> Accessories()
        {
            //IList<Accessory> list = serviceClass.Read();
            return _db.ExecuteDataSet("spGetAccessoryRecords").Tables[0].AsEnumerable().Select(row => new Accessory(Convert.ToInt32(row["AccessoryId"]), Convert.ToString(row["AccessoryName"]), Convert.ToInt32(row["Price"]))).ToList();

        }

        
        [HttpPost]
        [Route("addAccessory/{id}/{name}/{price}")]
        public IHttpActionResult AddAccessory(int id, string name, int price)
        {
            return Ok(_db.ExecuteNonQuery("spInsertAccessory", new object[] { id, name, price }));
        }
        

        [HttpDelete]
        [Route("deleteAccessory/{id}")] 
        public IHttpActionResult DeleteAccessory(int id)
        {
            return Ok(_db.ExecuteNonQuery("spDeleteAccessory", new object[] { id }));
        }
        

        [HttpPut]
        [Route("updateAccessory/{id}/{name}/{price}")]
        public IHttpActionResult UpdateAccessory(int id, string name, int price)
        {
            return Ok(_db.ExecuteNonQuery("spUpdateAccessory", new object[] { id, name, price }));
        }

        [HttpGet,Route("api/purchases")]
        public List<Purchase> Purchases()
        {
            return _db.ExecuteDataSet("spGetPurchaseRecords").Tables[0].AsEnumerable().Select(row => new Purchase(Convert.ToInt32(row["PurchaseId"]), Convert.ToInt32(row["AccessoryId"]), Convert.ToInt32(row["ClientId"]), Convert.ToInt32(row["Quantity"]), Convert.ToDateTime(row["PurchaseDate"]))).ToList();
        }

        [HttpPost, Route("api/purchases")]
        public IHttpActionResult Purchase([FromBody]StockPurchase stockPurchase)
        {
            return Ok(_db.ExecuteNonQuery("spInsertPurchase", new object[] { stockPurchase.accessoryId, stockPurchase.clientName, stockPurchase.quantity, DateTime.Now }));
        }

        [HttpPut, Route("api/purchases")]
        public IHttpActionResult BuyExtra([FromBody]Purchase purchase)
        {
            return Ok(_db.ExecuteNonQuery("spUpdatePurchase", new object[] { purchase.purchaseId, purchase.quantity }));
        }

        [HttpDelete, Route("api/purchases")]
        public IHttpActionResult Redo(int id)
        {
            return Ok(_db.ExecuteNonQuery("spDeletePurchase", new object[] { id }));
        }

    }
}
