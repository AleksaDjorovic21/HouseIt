using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HouseIt.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KitchenController(IKitchenRepository repository) : ControllerBase
{
    private readonly IKitchenRepository _repository = repository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Kitchen>>> GetAll()
    {
        var kitchens = await _repository.GetAllAsync();
        return Ok(kitchens);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Kitchen>> GetById(int id)
    {
        var kitchen = await _repository.GetByIdAsync(id);
        if (kitchen == null)
        {
            return NotFound();
        }
        return Ok(kitchen);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Kitchen kitchen)
    {
        await _repository.AddAsync(kitchen);
        return CreatedAtAction(nameof(GetById), new { id = kitchen.Id }, kitchen);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Kitchen kitchen)
    {
        if (id != kitchen.Id)
        {
            return BadRequest();
        }
        await _repository.UpdateAsync(kitchen);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}

