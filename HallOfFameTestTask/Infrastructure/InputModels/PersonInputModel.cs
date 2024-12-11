namespace HallOfFameTestTask.Infrastructure.InputModels;

/// <summary>
/// Входная модель данных человека.
/// </summary>
public class PersonInputModel
{
    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Отображаемое имя.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Список входных моделей навыков.
    /// </summary>
    public List<SkillInputModel> Skills { get; set; }
}
