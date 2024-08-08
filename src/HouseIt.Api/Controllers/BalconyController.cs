using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HouseIt.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BalconyController(IBalconyRepository repository) : ControllerBase
{
    private readonly IBalconyRepository _repository = repository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Balcony>>> GetAll()
    {
        var balconies = await _repository.GetAllAsync();
        return Ok(balconies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Balcony>> GetById(int id)
    {
        var balcony = await _repository.GetByIdAsync(id);
        if (balcony == null)
        {
            return NotFound();
        }
        return Ok(balcony);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Balcony balcony)
    {
        await _repository.AddAsync(balcony);
        return CreatedAtAction(nameof(GetById), new { id = balcony.Id }, balcony);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Balcony balcony)
    {
        if (id != balcony.Id)
        {
            return BadRequest();
        }
        await _repository.UpdateAsync(balcony);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}

