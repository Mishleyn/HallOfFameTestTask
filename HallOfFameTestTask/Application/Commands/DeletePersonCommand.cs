using MediatR;

namespace HallOfFameTestTask.Application.Commands;

public class DeletePersonCommand : IRequest<Unit>
{
    public long Id { get; set; }
}
