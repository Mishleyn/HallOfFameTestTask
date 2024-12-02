using HallOfFameTestTask.Domain.Model;
using MediatR;

namespace HallOfFameTestTask.Application.Queries;

public class GetAllPersonsQuery : IRequest<GetAllPersonsResult>
{
    public GetAllPersonsQuery()
    {

    }
}
