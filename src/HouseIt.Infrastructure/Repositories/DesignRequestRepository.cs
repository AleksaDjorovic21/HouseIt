using HouseIt.Core.Domain;
using HouseIt.Core.Interfaces;
using HouseIt.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseIt.Infrastructure.Repositories;

public class DesignRequestRepository(HouseItDbContext context) : IDesignRequestRepository
{
    private readonly HouseItDbContext _context = context;

    public async Task<IEnumerable<DesignRequest>> GetAllAsync()
    {
        return await _context.DesignRequests
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Rooms)
                    .ThenInclude(r => r.Doors)
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Rooms)
                    .ThenInclude(r => r.Windows)
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Kitchens)
                    .ThenInclude(k => k.Doors)
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Kitchens)
                    .ThenInclude(k => k.Windows)
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Toilets)
                    .ThenInclude(t => t.Doors)
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Toilets)
                    .ThenInclude(t => t.Windows)
            .ToListAsync();
    }

    public async Task<DesignRequest> GetByIdAsync(int id)
    {
        var designRequest = await _context.DesignRequests
        .Include(dr => dr.Floors)
            .ThenInclude(f => f.Rooms)
                .ThenInclude(r => r.Doors)
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Rooms)
                    .ThenInclude(r => r.Windows)
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Kitchens)
                    .ThenInclude(k => k.Doors)
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Kitchens)
                    .ThenInclude(k => k.Windows)
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Toilets)
                    .ThenInclude(t => t.Doors)
            .Include(dr => dr.Floors)
                .ThenInclude(f => f.Toilets)
                    .ThenInclude(t => t.Windows)
        .FirstOrDefaultAsync(dr => dr.Id == id) ?? throw new Exception($"Design request with id {id} not found.");

        return designRequest;
    }

    public async Task AddAsync(DesignRequest designRequest)
    {
        _context.DesignRequests.Add(designRequest);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DesignRequest designRequest)
    {
        _context.Entry(designRequest).State = EntityState.Modified;
        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(int id)
    {
        var designRequest = await _context.DesignRequests.FindAsync(id);
        if (designRequest != null)
        {
            _context.DesignRequests.Remove(designRequest);
            await _context.SaveChangesAsync();
        }
    }
}


