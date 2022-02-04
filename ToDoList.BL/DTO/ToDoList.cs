namespace ToDoList.BL.DTO;

public record CreateToDoListDto(string Name, string Description);

public record UpdateToDoListDto(string Name, string Description);

public record ToDoListInfoDto(Guid Id, string Name, string Description);

public record ToDoListDetailDto(Guid Id, string Name, string Description, List<ToDoListItemDto> Items);

public record AddToDoListItemDto(string Description);

public record UpdateToDoListItemDto(string Description);

public record ToDoListItemDto(Guid Id, string Description);