using Session.Data.Models;

namespace Session.Web.Models
{
    public class Item
    {
        public Toy Toy { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get => Toy.MToyRate * Quantity; }
    }
}
