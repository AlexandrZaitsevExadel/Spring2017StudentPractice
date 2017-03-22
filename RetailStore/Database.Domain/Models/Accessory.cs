namespace DBase.Domain.Models
{
    public class Accessory
    {
        public Accessory(int id, string name, int price)
        {
            AccessoryId = id;
            AccessoryName = name;
            this.Price = price;
        }
        public Accessory()
        {
            AccessoryId = 0;
            AccessoryName = "";
            Price = 0;
        }
        public int AccessoryId { get; set; }
        public string AccessoryName { get; set; }
        public int Price { get; set; }
    }
}
