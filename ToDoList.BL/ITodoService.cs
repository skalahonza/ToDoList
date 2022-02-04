using ToDoList.BL.DTO;

namespace ToDoList.BL;

public interface ITodoService
{
    Task<List<ToDoListInfoDto>> GetAll();

    Task<ToDoListDetailDto?> GetDetail(Guid id);

    Task<ToDoListDetailDto?> AddNew(CreateToDoListDto newToDo);

    Task<ToDoListDetailDto?> UpdateExisting(Guid id, UpdateToDoListDto toDo);

    Task<bool> DeleteExisting(Guid id);

    Task<ToDoListItemDto?> AddToDoListItem(Guid id, AddToDoListItemDto item);

    Task<ToDoListItemDto?> UpdateToDoListItem(Guid todoListId, Guid itemId, AddToDoListItemDto item);

    Task<bool> DeleteToDoListItem(Guid todoListId, Guid itemId);
}