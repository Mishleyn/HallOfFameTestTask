using HallOfFameTestTask.Application.Repositories;
using HallOfFameTestTask.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HallOfFameTestTask.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private Context _context;

    public PersonRepository(Context context)
    {
        _context = context;
    }

    public async Task<long> Create(Person person)
    {
        var result = await _context.AddAsync(person);
        await _context.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task Delete(Person person)
    {
        _context.Persons.Remove(person);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Person person)
    {
        _context.Entry(person).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public Person GetPerson(long id)
    {
        return _context.Persons.Find(id);
    }

    public Task<List<Person>> GetPersonsList()
    {
        var result = _context.Persons.ToListAsync();
        return result;
    }    

    public void Save()
    {
        _context.SaveChanges();
    }
}
