using HallOfFameTestTask.Application.Repositories;
using HallOfFameTestTask.Infrastructure.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace HallOfFameTestTask;

[Route("api/v1/[controller]")]
[ApiController]
public class PersonsController : ControllerBase
{
    public readonly IPersonRepository _personRepository;

    public PersonsController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    /// <summary>
    /// Получает всех людей.
    /// </summary>
    /// <returns see cref="OkResult">Успешно получен список пользователей.</returns>
    [HttpGet()]
    public async Task<IActionResult> GetAllAsync()
    {
        var persons = _personRepository.GetPersonsListAsync();
        return Ok(new { persons });
    }

    /// <summary>
    /// Получает человека.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <returns see cref="BadRequestResult">Не существует человека с указанным Id.</returns>
    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        try
        {
            var person = _personRepository.GetPerson(id);
            return Ok(new { person });
        }
        catch(ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Создает человека.
    /// </summary>
    /// <param name="model">Входная модель данных.</param>
    /// <returns see cref="BadRequestResult">Некорректные входные данные.</returns>
    [HttpPost()]
    public async Task<IActionResult> PostAsync(PersonInputModel model)
    {
        try
        {
            await _personRepository.CreateAsync(model);
            return Ok();
        }
        catch(ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }        
    }

    /// <summary>
    /// Обновляет полностью данные человека.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="model">Входная модель обновленных данных.</param>
    /// <returns see cref="OkResult">Успешное добавление.</returns>
    /// <returns see cref="NotFoundResult">Человек с таким Id не найден.</returns>
    /// <returns see cref="BadRequestResult">Некорректные входные данные.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, PersonInputModel model)
    {
        try
        {
            await _personRepository.UpdateAsync(id, model);
            return Ok();
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <returns see cref="NotFoundResult">Человек с таким Id не найден.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        try
        {
            await _personRepository.DeleteAsync(id);
            return Ok();
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
