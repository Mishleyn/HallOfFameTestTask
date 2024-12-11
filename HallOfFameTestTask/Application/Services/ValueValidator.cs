using HallOfFameTestTask.Domain.Model;

namespace HallOfFameTestTask.Application.Services;

/// <summary>
/// Сервисный класс для валидации данных.
/// </summary>
public static class ValueValidator
{
    /// <summary>
    /// Проверяет существует ли пользователь.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="person">Пользователь.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void CheckPersonExist(long id, Person person)
    {
        if (person == null)
        {
            throw new ArgumentNullException($"Person with id: {id} not found");
        }
    }
}
