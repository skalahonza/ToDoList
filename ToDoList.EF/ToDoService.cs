using Microsoft.EntityFrameworkCore;
using ToDoList.BL;
using ToDoList.BL.DTO;
using ToDoList.EF.Entities;

namespace ToDoList.EF;

public class ToDoService : ITodoService
{
    private readonly ToDoDbContext _context;

    public ToDoService(ToDoDbContext context)
    {
        _context = context;
    }

    public Task<List<ToDoListInfoDto>> GetAll() =>
        _context
            .Lists
            .Select(list => new ToDoListInfoDto(list.Id, list.Name, list.Description))
            .ToListAsync();

    public Task<ToDoListDetailDto?> GetDetail(int id) =>
        _context
            .Lists
            .Include(x => x.Items)
            .Select(list => new ToDoListDetailDto(list.Id,
                list.Name,
                list.Description,
                list.Items.Select(item => new ToDoListItemDto(item.Id, item.Description)).ToList()))
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<ToDoListDetailDto?> AddNew(CreateToDoListDto newToDo)
    {
        var list = new ToDoListEntity
        {
            Name = newToDo.Name,
            Description = newToDo.Description
        };
        _context.Lists.Add(list);
        await _context.SaveChangesAsync();
        return await GetDetail(list.Id);
    }

    public async Task<ToDoListDetailDto?> UpdateExisting(int id, UpdateToDoListDto toDo)
    {
        var list = await _context.Lists.FirstOrDefaultAsync(x => x.Id == id);
        if (list is null) return null;

        list.Name = toDo.Name;
        list.Description = toDo.Description;
        await _context.SaveChangesAsync();
        return await GetDetail(list.Id);
    }

    public async Task<bool> DeleteExisting(int id)
    {
        var list = await _context.Lists.FirstOrDefaultAsync(x => x.Id == id);
        if (list is null) return false;

        _context.Lists.Remove(list);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ToDoListItemDto?> AddToDoListItem(int id, AddToDoListItemDto item)
    {
        var list = await _context.Lists.FirstOrDefaultAsync(x => x.Id == id);
        if (list is null) return null;

        var todoItem = new ToDoItemEntity
        {
            Description = item.Description
        };
        list.Items.Add(todoItem);
        await _context.SaveChangesAsync();
        return new ToDoListItemDto(todoItem.Id, todoItem.Description);
    }

    public async Task<ToDoListItemDto?> UpdateToDoListItem(int todoListId, int itemId, AddToDoListItemDto item)
    {
        var todoItem =
            await _context.Items.FirstOrDefaultAsync(x => x.ToDoListEntityId == todoListId && x.Id == itemId);
        if (todoItem is null) return null;

        todoItem.Description = item.Description;
        await _context.SaveChangesAsync();
        return new ToDoListItemDto(todoItem.Id, todoItem.Description);
    }

    public async Task<bool> DeleteToDoListItem(int todoListId, int itemId)
    {
        var todoItem =
            await _context.Items.FirstOrDefaultAsync(x => x.ToDoListEntityId == todoListId && x.Id == itemId);
        if (todoItem is null) return false;

        _context.Items.Remove(todoItem);
        await _context.SaveChangesAsync();
        return true;
    }
}