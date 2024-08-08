using HouseIt.Core.Domain;

namespace HouseIt.Core.Interfaces;

public interface IDesignRequestService
{
    Task SubmitDesignRequestAsync(DesignRequest request);
}