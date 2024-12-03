using HallOfFameTestTask.Application.Commands;
using HallOfFameTestTask.Application.Repositories;
using HallOfFameTestTask.Application.Services;
using HallOfFameTestTask.Domain.Model;
using MediatR;

namespace HallOfFameTestTask.Infrastructure.Commands;

public class AddPersonHandler : IRequestHandler<AddPersonCommand, long>
{
    private readonly IPersonRepository _personRepository;

    public AddPersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<long> Handle(AddPersonCommand command, CancellationToken cancellationToken)
    {
        Person person = new Person();

        var persons = await _personRepository.GetPersonsList();
        var newId = persons.Any() ? persons.Max(p => p.Id) + 1 : 1;

        foreach(var skill in command.Skills)
        {
            ValueValidator.CheckSkillLevel(skill.Name, skill.Level);
        }

        person.Id = newId;
        person.Name = command.Name;
        person.DisplayName = command.DisplayName;
        person.Skills = command.Skills.Select(skillInputModel => new Skill
        {
            Id = new Guid(),
            Name = skillInputModel.Name,
            Level = skillInputModel.Level
        }).ToList();

        await _personRepository.Create(person);
        return person.Id;
    }
}
