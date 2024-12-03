using HallOfFameTestTask.Infrastructure.InputModels;

namespace HallOfFameTestTask.Infrastructure.OutputModels;

public class PersonOutputModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public List<SkillInputModel> Skills { get; set; }
}
