using HouseIt.Core.Domain;

namespace HouseIt.Core.Interfaces;

public interface IFloorRepository
{
    Task<IEnumerable<Floor>> GetAllAsync();
    Task<Floor> GetByIdAsync(int id);
    Task AddAsync(Floor floor);
    Task UpdateAsync(Floor floor);
    Task DeleteAsync(int id);
}