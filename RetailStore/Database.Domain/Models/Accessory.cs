namespace DBase.Domain.Models
{
    public class Accessory
    {
        public Accessory(int id, string name, int price)
        {
            this.accessoryId = id;
            this.accessoryName = name;
            this.price = price;
        }
        public Accessory()
        {
            this.accessoryId = 0;
            this.accessoryName = "";
            this.price = 0;
        }
        public int accessoryId { get; set; }
        public string accessoryName { get; set; }
        public int price { get; set; }
    }
}
