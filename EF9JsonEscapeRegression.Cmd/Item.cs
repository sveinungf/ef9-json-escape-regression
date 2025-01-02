namespace EF9JsonEscapeRegression.Cmd;

public class Item
{
    public int Id { get; init; }
    public required LocalizableString Name { get; set; }
}

public class LocalizableString
{
    public required string En { get; set; }
    public string? No { get; set; }
}