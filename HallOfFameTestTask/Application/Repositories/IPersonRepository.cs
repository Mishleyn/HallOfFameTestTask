using HallOfFameTestTask.Domain.Model;

namespace HallOfFameTestTask.Application.Repositories;

public interface IPersonRepository
{
    Task<List<Person>> GetPersonsList();

    Person GetPerson(long id);

    Task<long> Create(Person person);

    Task Update(Person person);

    Task Delete(Person person);

    void Save();
}
