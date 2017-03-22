using System.Collections.Generic;
using System.Web.Http;
using DBase.Domain.Models;
using DBase.Domain.Services;


namespace WebAPI.Controllers
{
    public class StockController : ApiController
    {
        
        private readonly IStoreService _serviceClass;
        
        public StockController()
        {
            _serviceClass = new StockService("WebAPI.Properties.Settings.ConnectionString");
        }

        [HttpGet]
        [Route("api/accessories")]
        public IList<Accessory> Accessories()
        {
            return _serviceClass.GetAccessories();

        }

        
        [HttpPost]
        [Route("addAccessory/{id}/{name}/{price}")]
        public IHttpActionResult AddAccessory(int id, string name, int price)
        {
            return Ok(_serviceClass.CreateAccessory(new Accessory(id, name, price)));
        }
        

        [HttpDelete]
        [Route("deleteAccessory/{id}")] 
        public IHttpActionResult DeleteAccessory(int id)
        {
            return Ok(_serviceClass.DeleteAccessory(id));
        }
        

        [HttpPut]
        [Route("updateAccessory/{id}/{name}/{price}")]
        public IHttpActionResult UpdateAccessory(int id, string name, int price)
        {
            return Ok(_serviceClass.UpdateAccessory(new Accessory(id, name, price)));
        }

        [HttpGet,Route("api/purchases")]
        public IList<Purchase> Purchases()
        {
            return _serviceClass.GetPurchases();
        }

        [HttpPost, Route("api/purchases")]
        public IHttpActionResult Purchase([FromBody]StockPurchase stockPurchase)
        {
            return Ok(_serviceClass.CreatePurchase(stockPurchase));
        }

        [HttpPut, Route("api/purchases")]
        public IHttpActionResult BuyExtra([FromBody]Purchase purchase)
        {
            return Ok(_serviceClass.UpdatePurchase(purchase));
        }

        [HttpDelete, Route("api/purchases")]
        public IHttpActionResult Redo(int id)
        {
            return Ok(_serviceClass.DeletePurchase(id));
        }

    }
}
