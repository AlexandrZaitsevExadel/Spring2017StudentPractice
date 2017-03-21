using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class StockPurchase
    {
        public int accessoryId;
        public string clientName;
        public int quantity;
        public StockPurchase()
        {
            accessoryId = 0;
            clientName = "Noname";
            quantity = 0;
        }
    }
}