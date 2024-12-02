using HallOfFameTestTask.Application.Commands;
using HallOfFameTestTask.Application.Repositories;
using HallOfFameTestTask.Domain.Model;

namespace HallOfFameTestTask.Infrastructure.Commands;

public class AddPersonHandler
{
    private readonly IPersonRepository _personRepository;

    public AddPersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<long> Handle(AddPersonCommand command, CancellationToken cancellationToken)
    {
        Person person = new Person();

        person.Id = command.Id;
        person.Name = command.Name;
        person.DisplayName = command.DisplayName;

        await _personRepository.Create(person);
        return person.Id;
    }
}
