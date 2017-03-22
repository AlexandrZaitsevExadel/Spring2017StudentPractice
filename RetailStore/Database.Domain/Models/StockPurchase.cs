using System;

namespace DBase.Domain.Models
{
    public class StockPurchase
    {
        public int AccessoryId { get; set; }
        public string ClientName { get; set; }
        public int Quantity { get; set; }

        public StockPurchase()
        {
            AccessoryId = 0;
            ClientName = "";
            Quantity = 0;
        }
        public StockPurchase(int accessoryId, string clientName, int quantity)
        {
            this.AccessoryId = accessoryId;
            this.ClientName = clientName;
            this.Quantity = quantity;
        }
    }
}