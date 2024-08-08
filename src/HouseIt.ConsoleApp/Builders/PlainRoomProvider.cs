using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

public class PlainRoomProvider : IRoomProvider<Room>
{
    public Room GetRoom(DesignRequest designRequest)
    {
        if (designRequest.Floors == null || !designRequest.Floors.Any())
            throw new InvalidOperationException("No floors found in the design request.");
        
        var lastFloor = designRequest.Floors.LastOrDefault() 
            ?? throw new InvalidOperationException("No floors found in the design request.");

        if (lastFloor.Rooms == null || !lastFloor.Rooms.Any())
            throw new InvalidOperationException("No rooms found in the last floor of the design request.");

        var lastRoom = lastFloor.Rooms.LastOrDefault() 
            ?? throw new InvalidOperationException("No rooms found in the last floor of the design request.");
            
        return lastRoom;
    }
}
