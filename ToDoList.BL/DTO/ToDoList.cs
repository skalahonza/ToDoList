namespace ToDoList.BL.DTO;

public record CreateToDoListDto(string Name, string Description);

public record UpdateToDoListDto(string Name, string Description);

// explicit DTO because of automapper
public record ToDoListInfoDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
}

// explicit DTO because of automapper
public record ToDoListDetailDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public IEnumerable<ToDoListItemDto> Items { get; init; }
}

public record AddToDoListItemDto(string Description);

public record UpdateToDoListItemDto(string Description);

// explicit DTO because of automapper
public record ToDoListItemDto
{
    public int Id { get; init; }
    public string Description { get; init; }
}