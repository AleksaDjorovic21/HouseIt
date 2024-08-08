using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HouseIt.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToiletController(IToiletRepository repository) : ControllerBase
{
    private readonly IToiletRepository _repository = repository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Toilet>>> GetAll()
    {
        var toilets = await _repository.GetAllAsync();
        return Ok(toilets);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Toilet>> GetById(int id)
    {
        var toilet = await _repository.GetByIdAsync(id);
        if (toilet == null)
        {
            return NotFound();
        }
        return Ok(toilet);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Toilet toilet)
    {
        await _repository.AddAsync(toilet);
        return CreatedAtAction(nameof(GetById), new { id = toilet.Id }, toilet);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Toilet toilet)
    {
        if (id != toilet.Id)
        {
            return BadRequest();
        }
        await _repository.UpdateAsync(toilet);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}

