using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using HouseIt.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseIt.Infrastructure.Repositories;

public class KitchenRepository(HouseItDbContext context) : IKitchenRepository
{
    private readonly HouseItDbContext _context = context;

    public async Task<IEnumerable<Kitchen>> GetAllAsync()
    {
        return await _context.Kitchens.ToListAsync();
    }

    public async Task<Kitchen> GetByIdAsync(int id)
    {
        var kitchen = await _context.Kitchens.FindAsync(id) ?? throw new Exception($"Kitchen with id {id} not found.");
        return kitchen;
    }

    public async Task AddAsync(Kitchen kitchen)
    {
        _context.Kitchens.Add(kitchen);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Kitchen kitchen)
    {
        _context.Entry(kitchen).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var kitchen = await _context.Kitchens.FindAsync(id);
        if (kitchen != null)
        {
            _context.Kitchens.Remove(kitchen);
            await _context.SaveChangesAsync();
        }
    }
}

