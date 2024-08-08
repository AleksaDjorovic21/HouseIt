using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using HouseIt.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseIt.Infrastructure.Repositories;

public class FloorRepository(HouseItDbContext context) : IFloorRepository
{
    private readonly HouseItDbContext _context = context;

    public async Task<IEnumerable<Floor>> GetAllAsync()
    {
        return await _context.Floors.ToListAsync();
    }

    public async Task<Floor> GetByIdAsync(int id)
    {
        var floor = await _context.Floors.FindAsync(id) ?? throw new Exception($"Floor with id {id} not found.");
        return floor;
    }

    public async Task AddAsync(Floor floor)
    {
        _context.Floors.Add(floor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Floor floor)
    {
        _context.Entry(floor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var floor = await _context.Floors.FindAsync(id);
        if (floor != null)
        {
            _context.Floors.Remove(floor);
            await _context.SaveChangesAsync();
        }
    }
}

