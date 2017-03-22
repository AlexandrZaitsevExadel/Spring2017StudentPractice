using System;

namespace DBase.Domain.Models
{
    public class StockPurchase
    {
        public int accessoryId { get; set; }
        public string clientName { get; set; }
        public int quantity { get; set; }

        public StockPurchase()
        {
            this.accessoryId = 0;
            this.clientName = "";
            this.quantity = 0;
        }
        public StockPurchase(int accessoryId, string clientName, int quantity)
        {
            this.accessoryId = accessoryId;
            this.clientName = clientName;
            this.quantity = quantity;
        }
    }
}