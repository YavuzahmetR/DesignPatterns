namespace DesignPattern.Repository.Models
{
    public class ProductUpdate_DeleteViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
