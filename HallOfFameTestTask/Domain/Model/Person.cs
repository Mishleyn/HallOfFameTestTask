namespace HallOfFameTestTask.Domain.Model;

public class Person
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public int? SkillsId { get; set; }

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
