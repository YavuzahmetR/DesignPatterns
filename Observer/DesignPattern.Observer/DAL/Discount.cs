using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPattern.Observer.DAL
{
    public class Discount
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; } = null!;
        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountAmount { get; set; }
        public bool IsPercentage { get; set; }
    }
}
