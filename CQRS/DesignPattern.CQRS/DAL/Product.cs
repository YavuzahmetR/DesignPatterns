using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        [Precision(9,2)]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
