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
        [Route("getAccessories")]
        public IHttpActionResult GetAllAccessories()
        {

            IList<Accessory> list = _db.ExecuteDataSet("spGetAccessoryRecords").Tables[0].AsEnumerable().Select(row => new Accessory(Convert.ToInt32(row["AccessoryId"]), Convert.ToString(row["AccessoryName"]), Convert.ToInt32(row["Price"]))).ToList();
            //IList<Accessory> list = serviceClass.Read();
            string output = new JavaScriptSerializer().Serialize(list);
            return Ok<string>(output);

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
        
    }
}
