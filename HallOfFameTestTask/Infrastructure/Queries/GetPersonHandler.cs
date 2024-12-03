using HallOfFameTestTask.Application.Queries;
using HallOfFameTestTask.Application.Repositories;
using HallOfFameTestTask.Application.Services;
using HallOfFameTestTask.Infrastructure.InputModels;
using HallOfFameTestTask.Infrastructure.OutputModels;
using MediatR;

namespace HallOfFameTestTask.Infrastructure.Queries;

public class GetPersonHandler : IRequestHandler<GetPersonQuery, GetPersonResult>
{
    private readonly IPersonRepository _personResository;

    public GetPersonHandler(IPersonRepository personResository)
    {
        _personResository = personResository;
    }

    public async Task<GetPersonResult> Handle(GetPersonQuery query, CancellationToken cancellationToken)
    {
        var person = _personResository.GetPerson(query.Id);
        ValueValidator.CheckPersonExist(query.Id, person);

        PersonOutputModel newPerson = new();
        newPerson.Id = person.Id;
        newPerson.Name = person.Name;
        newPerson.DisplayName = person.DisplayName;
        newPerson.Skills = person.Skills.Select(s => new SkillInputModel
                                { Name = s.Name, Level = s.Level }).ToList();

        return new GetPersonResult { Person = newPerson };
    }
}
