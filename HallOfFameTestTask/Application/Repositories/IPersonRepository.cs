using HallOfFameTestTask.Infrastructure.InputModels;
using HallOfFameTestTask.Infrastructure.OutputModels;

namespace HallOfFameTestTask.Application.Repositories;

/// <summary>
/// Содержит объявления методов для работы с человеком.
/// </summary>
public interface IPersonRepository
{
    /// <summary>
    /// Получает список всех людей.
    /// </summary>
    /// <returns>Список людей.</returns>
    Task<List<PersonOutputModel>> GetPersonsListAsync();

    /// <summary>
    /// Получает человека.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <returns>Человек.</returns>
    PersonOutputModel GetPerson(long id);

    /// <summary>
    /// Создает человека.
    /// </summary>
    /// <param name="model">Входная модель.</param>
    /// <returns>Уникальный идентификатор человека.</returns>
    Task CreateAsync(PersonInputModel model);

    /// <summary>
    /// Обновляет данные человека полностью.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="model">Входная модель.</param>    
    Task UpdateAsync(long id, PersonInputModel model);

    /// <summary>
    /// Удаляет человека.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    Task DeleteAsync(long id);
}
