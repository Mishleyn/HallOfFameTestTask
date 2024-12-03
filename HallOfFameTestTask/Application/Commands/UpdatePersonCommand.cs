using HallOfFameTestTask.Infrastructure.InputModels;
using MediatR;

namespace HallOfFameTestTask.Application.Commands;

public class UpdatePersonCommand : IRequest<long>
{
    public long Id { get; set; }

    public UpdatePersonInputModel Model { get; set; }

    public UpdatePersonCommand(long id, UpdatePersonInputModel model)
    {
        Id = id;
        Model = model;
    }
}
