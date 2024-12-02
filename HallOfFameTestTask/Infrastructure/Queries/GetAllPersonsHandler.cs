using HallOfFameTestTask.Application.Queries;
using HallOfFameTestTask.Application.Repositories;
using MediatR;

namespace HallOfFameTestTask.Infrastructure.Queries;

public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, GetAllPersonsResult>
{
    private readonly IPersonRepository _personResository;

    public GetAllPersonsHandler(IPersonRepository personResository)
    {
        _personResository = personResository;
    }

    public async Task<GetAllPersonsResult> Handle(GetAllPersonsQuery query, CancellationToken cancellationToken)
    {
        var person = await _personResository.GetPersonsList();

        return new GetAllPersonsResult
        {
            Persons = person
        };
    }
}
