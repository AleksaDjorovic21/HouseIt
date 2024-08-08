using HouseIt.Core.Domain;

namespace HouseIt.Core.Interfaces;

public interface IWindowRepository
{
    Task<IEnumerable<Window>> GetAllAsync();
    Task<Window> GetByIdAsync(int id);
    Task AddAsync(Window window);
    Task UpdateAsync(Window window);
    Task DeleteAsync(int id);
}

