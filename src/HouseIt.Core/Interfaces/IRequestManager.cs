using HouseIt.Core.Domain;

namespace HouseIt.Core.Interfaces;

public interface IRequestManager
{
    Task SubmitRequestAsync(DesignRequest request);
}

