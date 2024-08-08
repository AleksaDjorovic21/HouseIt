using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

public class ToiletRoomProvider : IRoomProvider<Toilet>
{
    public Toilet GetRoom(DesignRequest designRequest)
    {
        var lastFloor = designRequest.Floors.LastOrDefault() 
            ?? throw new InvalidOperationException("No floors found in the design request.");

        var lastToilet = lastFloor.Toilets.LastOrDefault() 
            ?? throw new InvalidOperationException("No toilets found in the last floor of the design request.");
            
        return lastToilet;
    }
}
