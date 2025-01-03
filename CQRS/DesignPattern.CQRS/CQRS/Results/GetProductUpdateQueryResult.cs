﻿namespace DesignPattern.CQRS.CQRS.Results
{
    public class GetProductUpdateQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
    }
}
