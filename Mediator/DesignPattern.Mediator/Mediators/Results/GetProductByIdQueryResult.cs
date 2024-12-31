namespace DesignPattern.Mediator.Mediators.Results
{
    public class GetProductByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Stock { get; set; }

    }
}
