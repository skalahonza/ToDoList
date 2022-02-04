namespace ToDoList.BL.DTO;

public record CreateToDoListDto(string Name, string Description);

public record UpdateToDoListDto(string Name, string Description);

public record ToDoListInfoDto(int Id, string Name, string Description);

public record ToDoListDetailDto(int Id, string Name, string Description, IEnumerable<ToDoListItemDto> Items);

public record AddToDoListItemDto(string Description);

public record UpdateToDoListItemDto(string Description);

public record ToDoListItemDto(int Id, string Description);