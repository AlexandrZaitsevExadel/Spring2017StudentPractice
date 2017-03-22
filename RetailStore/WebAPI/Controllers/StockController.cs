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
        
        private IStoreService serviceClass;
        
        public StockController()
        {
            serviceClass = new StockService("WebAPI.Properties.Settings.ConnectionString");
        }

        [HttpGet]
        [Route("api/accessories")]
        public IList<Accessory> Accessories()
        {
            return serviceClass.GetAccessories();

        }

        
        [HttpPost]
        [Route("addAccessory/{id}/{name}/{price}")]
        public IHttpActionResult AddAccessory(int id, string name, int price)
        {
            return Ok(serviceClass.CreateAccessory(new Accessory(id, name, price)));
        }
        

        [HttpDelete]
        [Route("deleteAccessory/{id}")] 
        public IHttpActionResult DeleteAccessory(int id)
        {
            return Ok(serviceClass.DeleteAccessory(id));
        }
        

        [HttpPut]
        [Route("updateAccessory/{id}/{name}/{price}")]
        public IHttpActionResult UpdateAccessory(int id, string name, int price)
        {
            return Ok(serviceClass.UpdateAccessory(new Accessory(id, name, price)));
        }

        [HttpGet,Route("api/purchases")]
        public IList<Purchase> Purchases()
        {
            return serviceClass.GetPurchases();
        }

        [HttpPost, Route("api/purchases")]
        public IHttpActionResult Purchase([FromBody]StockPurchase stockPurchase)
        {
            return Ok(serviceClass.CreatePurchase(stockPurchase));
        }

        [HttpPut, Route("api/purchases")]
        public IHttpActionResult BuyExtra([FromBody]Purchase purchase)
        {
            return Ok(serviceClass.UpdatePurchase(purchase));
        }

        [HttpDelete, Route("api/purchases")]
        public IHttpActionResult Redo(int id)
        {
            return Ok(serviceClass.DeletePurchase(id));
        }

    }
}
