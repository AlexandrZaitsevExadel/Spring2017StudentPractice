using System;
namespace DBase.Domain.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int AccessoryId { get; set; }
        public int ClientId { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Purchase()
        {
            PurchaseId = 0;
            AccessoryId = 0;
            ClientId = 0;
            Quantity = 0;
            PurchaseDate = DateTime.Now;
        }
        public Purchase(int purchaseId, int accessoryId, int clientId, int quantity, DateTime purchaseDate)
        {
            this.PurchaseId = purchaseId;
            this.AccessoryId = accessoryId;
            this.ClientId = clientId;
            this.Quantity = quantity;
            this.PurchaseDate = purchaseDate;
        }
    }
    
}
