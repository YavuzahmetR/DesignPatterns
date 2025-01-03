﻿namespace DesignPattern.CQRS.CQRS.Results
{
    public class GetProductByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = null!;
    }
}
