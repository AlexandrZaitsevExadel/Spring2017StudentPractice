using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using DBase.Domain.Models;
using System.Web.Http;

namespace DBase.Domain.Services
{
    public interface IStoreService
    {
        int CreateAccessory(Accessory accessoryTable);
        IList<Accessory> GetAccessories();
        int UpdateAccessory(Accessory accessoryTable);
        int DeleteAccessory(int id);
        IList<Purchase> GetPurchases();
        int CreatePurchase(StockPurchase stockPurchase);
        int UpdatePurchase(Purchase purchase);
        int DeletePurchase(int id);
    }

}
