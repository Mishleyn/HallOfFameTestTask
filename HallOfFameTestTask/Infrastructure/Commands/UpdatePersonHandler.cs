using HallOfFameTestTask.Application.Commands;
using HallOfFameTestTask.Application.Repositories;

namespace HallOfFameTestTask.Infrastructure.Commands;

public class UpdatePersonHandler
{
    private readonly IPersonRepository _personRepository;

    public UpdatePersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<long> Handle(UpdatePersonCommand command, CancellationToken cancellationToken)
    {
        var person = _personRepository.GetPerson(command.Id);
        person.Name = command.Name;
        person.DisplayName = command.DisplayName;
        person.Skills = command.Skills;

        await _personRepository.Update(person);
        return person.Id;
    }
}
