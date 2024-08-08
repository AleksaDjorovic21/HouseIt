using HouseIt.Core.Interfaces;
using HouseIt.Core.Domain;
using HouseIt.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseIt.Infrastructure.Repositories;

public class RoomRepository(HouseItDbContext context) : IRoomRepository
{
    private readonly HouseItDbContext _context = context;

    public async Task<IEnumerable<Room>> GetAllAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room> GetByIdAsync(int id)
    {
        var room = await _context.Rooms.FindAsync(id) ?? throw new Exception($"Room with id {id} not found.");
        return room;
    }

    public async Task AddAsync(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Room room)
    {
        _context.Entry(room).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room != null)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}

