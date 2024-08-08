using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HouseIt.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController(IRoomRepository repository) : ControllerBase
{
    private readonly IRoomRepository _repository = repository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetAll()
    {
        var rooms = await _repository.GetAllAsync();
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetById(int id)
    {
        var room = await _repository.GetByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Room room)
    {
        await _repository.AddAsync(room);
        return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Room room)
    {
        if (id != room.Id)
        {
            return BadRequest();
        }
        await _repository.UpdateAsync(room);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}

