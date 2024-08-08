using HouseIt.Core.Interfaces;

namespace HouseIt.Core.Domain;

public class RequestManager(IDesignRequestDocument doc, IRequestManager requestManager) : IRequestManager
{
    private readonly IRequestManager _requestManager = requestManager;
    private readonly IDesignRequestDocument document = doc ?? throw new ArgumentNullException(nameof(doc));

    public Task SubmitRequestAsync(DesignRequest request)
    {
        return _requestManager.SubmitRequestAsync(request);
    }
}
