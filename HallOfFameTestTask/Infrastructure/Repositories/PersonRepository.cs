using HallOfFameTestTask.Application.Repositories;
using HallOfFameTestTask.Application.Services;
using HallOfFameTestTask.Domain.Model;
using HallOfFameTestTask.Infrastructure.InputModels;
using HallOfFameTestTask.Infrastructure.OutputModels;
using Microsoft.EntityFrameworkCore;

namespace HallOfFameTestTask.Infrastructure.Repositories;

/// <summary>
/// Класс, реализующий интерфейс Person.
/// </summary>
public class PersonRepository : IPersonRepository
{
    private Context _context;

    public PersonRepository(Context context)
    {
        _context = context;
    }
    
    /// <summary>
    /// <inheritdoc/>
    /// </summary>    
    public async Task CreateAsync(PersonInputModel model)
    {
        Person person = new Person();
        var persons = await GetPersonsListAsync();
                        
        person.Name = model.Name;
        person.DisplayName = model.DisplayName;
        person.Skills = model.Skills.Select(skillInputModel => new Skill
        {
            Id = new Guid(),
            Name = skillInputModel.Name,
            Level = skillInputModel.Level
        }).ToList();

        var result = await _context.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task DeleteAsync(long id)
    {
        var person = _context.Persons.Find(id);
        ValueValidator.CheckPersonExist(id, person);
        
        _context.Persons.Remove(person);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task UpdateAsync(long id, PersonInputModel model)
    {
        var person = _context.Persons.Find(id);
        ValueValidator.CheckPersonExist(id, person);

        person.Name = model.Name;
        person.DisplayName = model.DisplayName;
        person.Skills = model.Skills.Select(skillInputModel => new Skill
        {
            Id = new Guid(),
            Name = skillInputModel.Name,
            Level = skillInputModel.Level
        }).ToList();

        _context.Entry(person).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns><inheritdoc/></returns>
    public PersonOutputModel GetPerson(long id)
    {
        var person = _context.Persons.Find(id);
        ValueValidator.CheckPersonExist(id, person);

        PersonOutputModel newPerson = new();
        newPerson.Id = person.Id;
        newPerson.Name = person.Name;
        newPerson.DisplayName = person.DisplayName;
        newPerson.Skills = person.Skills.Select(s => new SkillInputModel
        { Name = s.Name, Level = s.Level }).ToList();

        return newPerson;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns><inheritdoc/></returns>
    public async Task<List<PersonOutputModel>> GetPersonsListAsync()
    {
        var persons = await _context.Persons.ToListAsync();
        List<PersonOutputModel> personOutputModels = new();

        foreach (var p in persons)
        {
            PersonOutputModel newPerson = new();
            newPerson.Id = p.Id;
            newPerson.Name = p.Name;
            newPerson.DisplayName = p.DisplayName;
            newPerson.Skills = p.Skills.Select(s => new SkillInputModel
            { Name = s.Name, Level = s.Level }).ToList();
            personOutputModels.Add(newPerson);
        }
               
        return personOutputModels;
    }    
}
