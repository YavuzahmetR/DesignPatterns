using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPattern.Facade.DAL
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; } = null!;
    }
}
