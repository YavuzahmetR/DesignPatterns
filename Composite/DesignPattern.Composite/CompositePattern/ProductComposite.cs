using System.Text;

namespace DesignPattern.Composite.CompositePattern
{
    public class ProductComposite : IComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private List<IComponent> _components;
        public ProductComposite(int id, string name)
        {
            Id = id;
            Name = name;
            _components = new List<IComponent>();
        }
        public ICollection<IComponent> Components
        {
            get { return _components; }
        }
        public int Count()
        {
            return _components.Sum(c => c.Count());
        }

        public string Display()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"<div class='text-success'>{Name} ({Count()})</div>");
            stringBuilder.Append($"<ul class='list-group list-group-flush ms-2'>");
            foreach (var component in _components)
            {
                stringBuilder.Append(component.Display());
            }
            stringBuilder.Append("</ul>");
            return stringBuilder.ToString();
        }
    }
}
