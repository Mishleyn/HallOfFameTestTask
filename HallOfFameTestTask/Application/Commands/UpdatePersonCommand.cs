using HallOfFameTestTask.Domain.Model;

namespace HallOfFameTestTask.Application.Commands;

public class UpdatePersonCommand
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public List<Skill> Skills { get; set; }
}
