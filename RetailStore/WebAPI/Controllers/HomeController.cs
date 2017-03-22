using System.Web.Mvc;
using DBase.Domain.Models;
using DBase.Domain.Services;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreService _serviceClass;

        public HomeController()
        {
            _serviceClass = new StockService("WebAPI.Properties.Settings.ConnectionString");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Accessories = _serviceClass.GetAccessories();
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.AccessoryId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(StockPurchase stockPurchase)
        {

            _serviceClass.CreatePurchase(stockPurchase);
            Purchase();
            return View("Purchase");
        }


        public ActionResult Purchase()
        {
            ViewBag.Purchases = _serviceClass.GetPurchases();
            return View();
        }

        [HttpGet]
        public ActionResult BuyExtra(int id)
        {
            ViewBag.PurchaseId = id;
            return View();
        }

        [HttpPost]
        public ActionResult BuyExtra(Purchase purchase)
        {
            _serviceClass.UpdatePurchase(purchase);
            Purchase();
            return View("Purchase");
        }

        [HttpPost]
        public ActionResult Redo(Purchase purchase)
        {
            _serviceClass.DeletePurchase(purchase.PurchaseId);
            Purchase();
            return View("Purchase");
        }

        [HttpGet]
        public ActionResult Redo(int id)
        {
            ViewBag.PurchaseId = id;
            return View();
        }



    }
}
