using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPattern.Mediator.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string StockType { get; set; } = null!;
    }
}
