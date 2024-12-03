using HallOfFameTestTask.Application.Commands;
using HallOfFameTestTask.Application.Queries;
using HallOfFameTestTask.Infrastructure.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HallOfFameTestTask;

[Route("api/v1/[controller]")]
[ApiController]
public class PersonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var persons = await _mediator.Send(new GetAllPersonsQuery());
        return Ok(new { persons });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerson(long id)
    {
        try
        {
            var person = await _mediator.Send(new GetPersonQuery(id));
            return Ok(new { person });
        }
        catch(ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost()]
    public async Task<IActionResult> Post(AddPersonCommand command)
    {
        try
        {
            await _mediator.Send(command);
            return Ok("Succesfull");
        }
        catch(ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }        
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(long id, UpdatePersonInputModel model)
    {
        try
        {
            UpdatePersonCommand command = new UpdatePersonCommand(id, model);
            var person = await _mediator.Send(command);
            return Ok("Succesfull");
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            DeletePersonCommand command = new DeletePersonCommand(id);
            await _mediator.Send(command);
            return Ok("Succesfull");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
