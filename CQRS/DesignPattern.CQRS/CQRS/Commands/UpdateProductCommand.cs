﻿namespace DesignPattern.CQRS.CQRS.Commands
{
    public class UpdateProductCommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
    }
}
