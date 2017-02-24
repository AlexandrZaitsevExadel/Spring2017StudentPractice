namespace DBase.Domain.Models
{
    public class AccessoryTable
    {
        public AccessoryTable(int id, string name, int price)
        {
            this.accessoryId = id;
            this.accessoryName = name;
            this.price = price;
        }
        
        public int accessoryId { get; set; }
        public string accessoryName { get; set; }
        public int price { get; set; }
    }
}
