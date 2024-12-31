using DesignPattern.Mediator.Mediators.Results;
using MediatR;

namespace DesignPattern.Mediator.Mediators.Queries
{
    public class GetAllProductsQuery : IRequest<List<GetAllProductQueryResults>>
    {
    }
}
