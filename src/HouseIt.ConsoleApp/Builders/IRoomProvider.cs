using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

public interface IRoomProvider<TRoom> where TRoom : RoomBase, new()
{
    public TRoom GetRoom(DesignRequest designRequest);
}
