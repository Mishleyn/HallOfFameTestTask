using HallOfFameTestTask.Domain.Model;

namespace HallOfFameTestTask.Application.Services;

public static class ValueValidator
{
    public static void CheckPersonExist(long id, Person person)
    {
        if (person == null)
        {
            throw new ArgumentNullException($"Person with id: {id} not found");
        }
    }

    public static void CheckSkillLevel(string name, byte level)
    {
        if (level > 10 || level < 1)
        {
            throw new ArgumentException($"{name} level must be in range [0,10]");
        }
    }
}
