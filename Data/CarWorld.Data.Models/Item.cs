using CarWorld.Data.Common.Models;

namespace CarWorld.Data.Models
{
    public class Item : BaseModel<int>
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quanity { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
