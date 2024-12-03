using HallOfFameTestTask.Application.Queries;
using HallOfFameTestTask.Application.Repositories;
using HallOfFameTestTask.Infrastructure.InputModels;
using HallOfFameTestTask.Infrastructure.OutputModels;
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

        var result = new GetAllPersonsResult();

        foreach(var p in person)
        {
            PersonOutputModel newPerson = new();
            newPerson.Id = p.Id;
            newPerson.Name = p.Name;
            newPerson.DisplayName = p.DisplayName;
            newPerson.Skills = p.Skills.Select(s => new SkillInputModel 
                                        { Name = s.Name, Level = s.Level }).ToList();
            result.Persons.Add(newPerson);
        }

        return result;
    }
}
