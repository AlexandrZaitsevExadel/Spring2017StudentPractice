using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DBase.Domain.Models;
using DBase.Domain.Services;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private IStoreService serviceClass;

        public HomeController()
        {
            serviceClass = new StockService("WebAPI.Properties.Settings.ConnectionString");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Accessories = serviceClass.GetAccessories();
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
        public ActionResult Buy(StockPurchase stockPurchase)
        {

            serviceClass.CreatePurchase(stockPurchase);
            Purchase();
            return View("Purchase");
        }


        public ActionResult Purchase()
        {
            ViewBag.Purchases = serviceClass.GetPurchases();
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
            serviceClass.UpdatePurchase(purchase);
            Purchase();
            return View("Purchase");
        }

        [HttpPost]
        public ActionResult Redo(Purchase purchase)
        {
            serviceClass.DeletePurchase(purchase.purchaseId);
            Purchase();
            return View("Purchase");
        }

        [HttpGet]
        public ActionResult Redo(int id)
        {
            ViewBag.purchaseId = id;
            return View();
        }



    }
}
