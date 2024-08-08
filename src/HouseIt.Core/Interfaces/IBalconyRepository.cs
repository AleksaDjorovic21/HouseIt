using HouseIt.Core.Domain;

namespace HouseIt.Core.Interfaces;

public interface IBalconyRepository
{
    Task<IEnumerable<Balcony>> GetAllAsync();
    Task<Balcony> GetByIdAsync(int id);
    Task AddAsync(Balcony balcony);
    Task UpdateAsync(Balcony balcony);
    Task DeleteAsync(int id);
}