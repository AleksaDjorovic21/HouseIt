using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using HouseIt.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseIt.Infrastructure.Repositories;

public class ToiletRepository(HouseItDbContext context) : IToiletRepository
{
    private readonly HouseItDbContext _context = context;

    public async Task<IEnumerable<Toilet>> GetAllAsync()
    {
        return await _context.Toilets.ToListAsync();
    }

    public async Task<Toilet> GetByIdAsync(int id)
    {
        var toilet = await _context.Toilets.FindAsync(id) ?? throw new Exception($"Toilet with id {id} not found.");
        return toilet;
    }

    public async Task AddAsync(Toilet toilet)
    {
        _context.Toilets.Add(toilet);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Toilet toilet)
    {
        _context.Entry(toilet).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var toilet = await _context.Toilets.FindAsync(id);
        if (toilet != null)
        {
            _context.Toilets.Remove(toilet);
            await _context.SaveChangesAsync();
        }
    }
}

