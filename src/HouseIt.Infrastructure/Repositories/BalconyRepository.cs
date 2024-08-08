using HouseIt.Infrastructure.Persistence;
using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace HouseIt.Infrastructure.Repositories;

public class BalconyRepository(HouseItDbContext context) : IBalconyRepository
{
    private readonly HouseItDbContext _context = context;

    public async Task<IEnumerable<Balcony>> GetAllAsync()
    {
        return await _context.Balconies.ToListAsync();
    }

    public async Task<Balcony> GetByIdAsync(int id)
    {
        var balcony = await _context.Balconies.FindAsync(id) ?? throw new Exception($"Balcony with id {id} not found.");
        return balcony;
    }

    public async Task AddAsync(Balcony balcony)
    {
        _context.Balconies.Add(balcony);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Balcony balcony)
    {
        _context.Entry(balcony).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var balcony = await _context.Balconies.FindAsync(id);
        if (balcony != null)
        {
            _context.Balconies.Remove(balcony);
            await _context.SaveChangesAsync();
        }
    }
}

