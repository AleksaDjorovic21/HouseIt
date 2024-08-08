using HouseIt.Core.Domain;

namespace HouseIt.Core.Interfaces;

public interface IToiletRepository
{
    Task<IEnumerable<Toilet>> GetAllAsync();
    Task<Toilet> GetByIdAsync(int id);
    Task AddAsync(Toilet toilet);
    Task UpdateAsync(Toilet toilet);
    Task DeleteAsync(int id);
}

