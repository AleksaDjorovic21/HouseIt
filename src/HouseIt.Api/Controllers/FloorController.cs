using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HouseIt.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FloorController(IFloorRepository repository) : ControllerBase
{
    private readonly IFloorRepository _repository = repository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Floor>>> GetAll()
    {
        var floors = await _repository.GetAllAsync();
        return Ok(floors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Floor>> GetById(int id)
    {
        var floor = await _repository.GetByIdAsync(id);
        if (floor == null)
        {
            return NotFound();
        }
        return Ok(floor);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Floor floor)
    {
        await _repository.AddAsync(floor);
        return CreatedAtAction(nameof(GetById), new { id = floor.Id }, floor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Floor floor)
    {
        if (id != floor.Id)
        {
            return BadRequest();
        }
        await _repository.UpdateAsync(floor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}

