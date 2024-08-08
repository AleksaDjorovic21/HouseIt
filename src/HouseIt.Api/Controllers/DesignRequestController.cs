using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HouseIt.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DesignRequestController(IDesignRequestRepository repository) : ControllerBase
{
    private readonly IDesignRequestRepository _repository = repository;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DesignRequest>>> GetAll()
    {
        var designRequests = await _repository.GetAllAsync();
        return Ok(designRequests);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DesignRequest>> GetById(int id)
    {
        var designRequest = await _repository.GetByIdAsync(id);
        if (designRequest == null)
        {
            return NotFound();
        }
        return Ok(designRequest);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] DesignRequest designRequest)
    { 
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (designRequest == null)
        {
            return BadRequest("Your request is empty");
        }

        if (designRequest.Floors == null || !designRequest.Floors.Any())
        {
            return BadRequest("Your request must include at least one floor");
        }
         
        await _repository.AddAsync(designRequest);
        return CreatedAtAction(nameof(GetById), new { id = designRequest.Id }, designRequest);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DesignRequest designRequest)
    {
        if (id != designRequest.Id)
        {
            return BadRequest();
        }
        await _repository.UpdateAsync(designRequest);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
