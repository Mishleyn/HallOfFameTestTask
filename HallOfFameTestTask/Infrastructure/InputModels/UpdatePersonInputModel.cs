namespace HallOfFameTestTask.Infrastructure.InputModels;

public class UpdatePersonInputModel
{
    public string Name { get; set; }

    public string DisplayName { get; set; }

    public List<SkillInputModel> Skills { get; set; }
}
