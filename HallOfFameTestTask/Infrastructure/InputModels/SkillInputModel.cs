using System.ComponentModel.DataAnnotations;

namespace HallOfFameTestTask.Infrastructure.InputModels;

/// <summary>
/// Входная модель навыка.
/// </summary>
public class SkillInputModel
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Уровень владения.
    /// </summary>
    [Range(1, 10, ErrorMessage = "Level must be between 1 and 10.")]
    public byte Level { get; set; }
}
