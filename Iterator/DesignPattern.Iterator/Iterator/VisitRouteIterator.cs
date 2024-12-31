namespace DesignPattern.Iterator.Iterator
{
    public class VisitRouteIterator : IIterator<VisitRoute>
    {
        private VisitRouteMover _routeMover;
        private int current = 0;
        public VisitRouteIterator(VisitRouteMover routeMover)
        {
            _routeMover = routeMover;
        }
        public VisitRoute CurrentItem { get; set; } 
        public bool Next()
        {
            if (current < _routeMover.VisitRouteCount)
            {
                CurrentItem = _routeMover.VisitRoutes[current];
                current++;
                return true;
            }
            return false;
        }
    }
    
    
}
