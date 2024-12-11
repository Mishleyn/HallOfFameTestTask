using System.ComponentModel.DataAnnotations;

namespace HallOfFameTestTask.Domain.Model;

/// <summary>
/// Навык.
/// </summary>
public class Skill
{
    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Уровень владения.
    /// </summary>
    [Range(1, 10, ErrorMessage = "Level must be between 1 and 10.")]
    public byte Level { get; set; }

    public Skill(string name, byte level)
    {
        Name = name;
        Level = level;
    }

    public Skill()
    {

    }
}
