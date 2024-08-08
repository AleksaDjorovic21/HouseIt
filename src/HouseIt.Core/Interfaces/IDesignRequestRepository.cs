using HouseIt.Core.Domain;

namespace HouseIt.Core.Interfaces;

public interface IDesignRequestRepository
{
    Task<IEnumerable<DesignRequest>> GetAllAsync();
    Task<DesignRequest> GetByIdAsync(int id);
    Task AddAsync(DesignRequest designRequest);
    Task UpdateAsync(DesignRequest designRequest);
    Task DeleteAsync(int id);
}