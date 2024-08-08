using HouseIt.Core.Domain;

namespace HouseIt.Core.Interfaces;

public interface IDoorRepository
{
    Task<IEnumerable<Door>> GetAllAsync();
    Task<Door> GetByIdAsync(int id);
    Task AddAsync(Door door);
    Task UpdateAsync(Door door);
    Task DeleteAsync(int id);
}