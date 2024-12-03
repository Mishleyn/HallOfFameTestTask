using HallOfFameTestTask.Application.Commands;
using HallOfFameTestTask.Application.Repositories;
using HallOfFameTestTask.Application.Services;
using HallOfFameTestTask.Domain.Model;
using MediatR;

namespace HallOfFameTestTask.Infrastructure.Commands;

public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, long>
{
    private readonly IPersonRepository _personRepository;

    public UpdatePersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<long> Handle(UpdatePersonCommand command, CancellationToken cancellationToken)
    {
        var person = _personRepository.GetPerson(command.Id);
        ValueValidator.CheckPersonExist(command.Id, person);

        foreach(var skill in command.Model.Skills)
        {
            ValueValidator.CheckSkillLevel(skill.Name, skill.Level);
        }

        person.Name = command.Model.Name;
        person.DisplayName = command.Model.DisplayName;       
        person.Skills = command.Model.Skills.Select(skillInputModel => new Skill
        {
            Id = new Guid(),
            Name = skillInputModel.Name,
            Level = skillInputModel.Level
        }).ToList();

        await _personRepository.Update(person);
        return person.Id;
    }
}
