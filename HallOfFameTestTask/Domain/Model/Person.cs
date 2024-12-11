namespace HallOfFameTestTask.Domain.Model;

/// <summary>
/// Человек.
/// </summary>
public class Person
{
    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Отображаемое имя.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Уникальный идентификатор списка навыков для связи в бд.
    /// </summary>
    public int? SkillsId { get; set; }

    /// <summary>
    /// Список навыков.
    /// </summary>
    public List<Skill> Skills { get; set; }

    public Person(long id, string name, string displayName, List<Skill> skills)
    {
        Id = id;
        Name = name;
        DisplayName = displayName;
        Skills = skills;
    }

    public Person()
    {
        Skills = new List<Skill>();
    }
}
