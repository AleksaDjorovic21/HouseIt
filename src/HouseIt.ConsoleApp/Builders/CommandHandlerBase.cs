using System.Diagnostics.CodeAnalysis;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

[method: SetsRequiredMembers]
public abstract class CommandHandlerBase(string key, string description)
{
    public required string Key { get; set; } = key;
    public required string Description { get; set; } = description;
    public abstract void Handle(DesignRequest designRequest);
}
