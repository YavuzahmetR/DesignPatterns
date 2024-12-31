using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPattern.Facade.DAL
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int? ProductsId { get; set; }
        public Products Product { get; set; } = null!;
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int? OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int Count { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        public int Total { get; set; }
    }
}
