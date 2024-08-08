using HouseIt.Core.Domain;

namespace HouseIt.Core.Interfaces;

public interface IKitchenRepository
{
    Task<IEnumerable<Kitchen>> GetAllAsync();
    Task<Kitchen> GetByIdAsync(int id);
    Task AddAsync(Kitchen kitchen);
    Task UpdateAsync(Kitchen kitchen);
    Task DeleteAsync(int id);
}
