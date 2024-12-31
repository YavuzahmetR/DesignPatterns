using System.ComponentModel.DataAnnotations.Schema;

namespace DesignPattern.Mediator.Mediators.Results
{
    public class GetAllProductQueryResults
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string StockType { get; set; } = null!;
    }
}
