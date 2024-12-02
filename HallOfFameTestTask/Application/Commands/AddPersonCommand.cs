using HallOfFameTestTask.Domain.Model;
using MediatR;

namespace HallOfFameTestTask.Application.Commands;

public class AddPersonCommand : IRequest<int>
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public List<Skill> Skills { get; set; }
}
