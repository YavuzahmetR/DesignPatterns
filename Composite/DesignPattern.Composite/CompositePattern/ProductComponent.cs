﻿namespace DesignPattern.Composite.CompositePattern
{
    public class ProductComponent : IComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProductComponent(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Count()
        {
            return 1;
        }

        public string Display()
        {
           return $"<li class='list-group-item'>{Name}</li>";
        }
    }
}
