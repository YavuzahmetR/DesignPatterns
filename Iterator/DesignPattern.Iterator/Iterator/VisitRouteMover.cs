namespace DesignPattern.Iterator.Iterator
{
    public class VisitRouteMover : IMover<VisitRoute>
    {
        public List<VisitRoute> VisitRoutes { get; set; } = new List<VisitRoute>();

        public void AddVisitRoute(VisitRoute visitRoute)
        {
            VisitRoutes.Add(visitRoute);
        }   
        public int VisitRouteCount => VisitRoutes.Count;
        public IIterator<VisitRoute> CreateIterator()
        {
            return new VisitRouteIterator(this);
        }
    }
    
    
}
