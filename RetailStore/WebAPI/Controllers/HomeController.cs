using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DBase.Domain.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private Database _db;

        public HomeController()
        {
            _db = DatabaseFactory.CreateDatabase("WebAPI.Properties.Settings.ConnectionString");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Accessories = _db.ExecuteDataSet("spGetAccessoryRecords").Tables[0].AsEnumerable().Select(row => new Accessory(Convert.ToInt32(row["AccessoryId"]), Convert.ToString(row["AccessoryName"]), Convert.ToInt32(row["Price"]))).ToList();
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.accessoryId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase, string clientName)
        {

            purchase.purchaseDate = DateTime.Now;
            _db.ExecuteNonQuery("spInsertPurchase", new object[] { purchase.accessoryId, clientName, purchase.quantity, purchase.purchaseDate });
            Purchase();
            return View("Purchase");
        }


        public ActionResult Purchase()
        {
            ViewBag.Purchases = _db.ExecuteDataSet("spGetPurchaseRecords").Tables[0].AsEnumerable().Select(row => new Purchase(Convert.ToInt32(row["PurchaseId"]), Convert.ToInt32(row["AccessoryId"]), Convert.ToInt32(row["ClientId"]), Convert.ToInt32(row["Quantity"]), Convert.ToDateTime(row["PurchaseDate"]))).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult BuyExtra(int id)
        {
            ViewBag.purchaseId = id;
            return View();
        }

        [HttpPost]
        public ActionResult BuyExtra(Purchase purchase)
        {
            _db.ExecuteNonQuery("spUpdatePurchase", new object[] { purchase.purchaseId, purchase.quantity });
            Purchase();
            return View("Purchase");
        }

        [HttpPost]
        public ActionResult Redo(Purchase purchase)
        {
            _db.ExecuteNonQuery("spDeletePurchase", new object[] { purchase.purchaseId });
            Purchase();
            return View("Purchase");
        }

        [HttpGet]
        public ActionResult Redo(int id)
        {
            ViewBag.purchaseId = id;
            return View();
        }



        //Вероятно стоит создать отдельный файл для констант, куда, например, названия сторед процедур складывать..
    }
}
