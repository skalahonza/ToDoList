using ToDoList.BL.DTO;

namespace ToDoList.BL;

public interface ITodoService
{
    Task<List<ToDoListInfoDto>> GetAll();

    Task<ToDoListDetailDto?> GetDetail(int id);

    Task<ToDoListDetailDto?> AddNew(CreateToDoListDto newToDo);

    Task<ToDoListDetailDto?> UpdateExisting(int id, UpdateToDoListDto toDo);

    Task<bool> DeleteExisting(int id);

    Task<ToDoListItemDto?> AddToDoListItem(int id, AddToDoListItemDto item);

    Task<ToDoListItemDto?> UpdateToDoListItem(int todoListId, int itemId, AddToDoListItemDto item);

    Task<bool> DeleteToDoListItem(int todoListId, int itemId);
}