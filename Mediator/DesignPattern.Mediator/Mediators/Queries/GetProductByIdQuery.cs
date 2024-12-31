using DesignPattern.Mediator.Mediators.Results;
using MediatR;

namespace DesignPattern.Mediator.Mediators.Queries
{
    public class GetProductByIdQuery :IRequest<GetProductByIdQueryResult>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
