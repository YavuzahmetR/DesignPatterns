using MediatR;

namespace DesignPattern.Mediator.Mediators.Commands
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string StockType { get; set; } = null!;
    }
}
