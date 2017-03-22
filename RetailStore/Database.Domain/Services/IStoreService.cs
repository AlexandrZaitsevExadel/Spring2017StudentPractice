using System.Collections.Generic;
using DBase.Domain.Models;

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
