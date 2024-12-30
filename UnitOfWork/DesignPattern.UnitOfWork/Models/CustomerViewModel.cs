using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPattern.UnitOfWork.Models
{
    public class CustomerProcessViewModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; } 
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cost { get; set; }
    }
}

