using DesignPattern.Mediator.Mediators.Results;
using MediatR;

namespace DesignPattern.Mediator.Mediators.Queries
{
    public class UpdateProductByIdQuery : IRequest<UpdateProductByIdQueryResult>
    {
        public int Id { get; set; }
        public UpdateProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
