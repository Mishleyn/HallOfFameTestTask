using HallOfFameTestTask.Domain.Model;

namespace HallOfFameTestTask.Application.Queries;

public class GetAllPersonsResult
{
    public List<Person> Persons { get; set; }
}
