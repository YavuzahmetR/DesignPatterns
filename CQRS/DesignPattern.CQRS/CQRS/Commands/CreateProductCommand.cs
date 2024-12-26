namespace DesignPattern.CQRS.CQRS.Commands
{
    public class CreateProductCommand
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; } 

    }
}
