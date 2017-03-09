using System;
namespace DBase.Domain.Models
{
    public class Purchase
    {
        public int purchaseId { get; set; }
        public int accessoryId { get; set; }
        public int clientId { get; set; }
        public int quantity { get; set; }
        public DateTime purchaseDate { get; set; }
        public Purchase()
        {
            purchaseId = 0;
            accessoryId = 0;
            clientId = 0;
            quantity = 0;
            purchaseDate = DateTime.Now;
        }
        public Purchase(int purchaseId, int accessoryId, int clientId, int quantity, DateTime purchaseDate)
        {
            this.purchaseId = purchaseId;
            this.accessoryId = accessoryId;
            this.clientId = clientId;
            this.quantity = quantity;
            this.purchaseDate = purchaseDate;
        }
    }
    
}
