using Microsoft.EntityFrameworkCore;

namespace eAccountant.Database;

[PrimaryKey(nameof(Name))]
public class Setting
{
    public required string Name { get; init; }
    public required string Value { get; set; }
}