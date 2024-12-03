using MediatR;

namespace HallOfFameTestTask.Application.Queries;

public class GetPersonQuery : IRequest<GetPersonResult>
{
    public long Id { get; set; }

    public GetPersonQuery(long id)
    {
        Id = id;
    }
}
