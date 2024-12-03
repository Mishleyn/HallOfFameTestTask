using HallOfFameTestTask.Application.Commands;
using HallOfFameTestTask.Application.Repositories;
using HallOfFameTestTask.Application.Services;
using MediatR;


namespace HallOfFameTestTask.Infrastructure.Commands;

public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, Unit>
{
    private readonly IPersonRepository _personRepository;

    public DeletePersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Unit> Handle(DeletePersonCommand command, CancellationToken cancellationToken)
    {
        var person = _personRepository.GetPerson(command.Id);
        ValueValidator.CheckPersonExist(command.Id, person);

        await _personRepository.Delete(person);
        return Unit.Task.Result;
    }
}
