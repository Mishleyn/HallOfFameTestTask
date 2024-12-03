namespace HallOfFameTestTask.Domain.Model;

public class Skill
{
    public Guid Id { get; set; }

    public string Name { get; set; }

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
