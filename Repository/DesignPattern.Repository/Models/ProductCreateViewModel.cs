using DesignPattern.Entity.Concrete;

namespace DesignPattern.Repository.Models
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; } = null!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
