using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

public class KitchenRoomProvider : IRoomProvider<Kitchen>
{
    public Kitchen GetRoom(DesignRequest designRequest)
    {
        var lastFloor = designRequest.Floors.LastOrDefault() 
            ?? throw new InvalidOperationException("No floors found in the design request.");

        var lastKitchen = lastFloor.Kitchens.LastOrDefault() 
            ?? throw new InvalidOperationException("No kitchens found in the last floor of the design request.");
            
        return lastKitchen;
    }
}
