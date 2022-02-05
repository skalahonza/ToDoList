using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ToDoList.BL;
using ToDoList.BL.DTO;
using ToDoList.Mongo.Entities;
using ToDoList.Mongo.Extensions;

namespace ToDoList.Mongo;

public class ToDoService : ITodoService
{
    private readonly ToDoMongoDbContext _context;
    private readonly IMapper _mapper;

    public ToDoService(ToDoMongoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<List<ToDoListInfoDto>> GetAll() =>
        _context
            .Lists
            .AsQueryable()
            .MapTo<ToDoListInfoDto>(_mapper)
            //.Select(list => new ToDoListInfoDto(list.Id, list.Name, list.Description))
            .ToListAsync();

    public Task<ToDoListDetailDto?> GetDetail(int id) =>
        _context
            .Lists
            .AsQueryable()
            .Where(x => x.Id == id)
            .MapTo<ToDoListDetailDto>(_mapper)
            /*.Select(list => new ToDoListDetailDto(list.Id,
                list.Name,
                list.Description,
                list.Items.Select(item => new ToDoListItemDto(item.Id, item.Description))))*/
            .FirstOrDefaultAsync()!;

    public async Task<ToDoListDetailDto?> AddNew(CreateToDoListDto newToDo)
    {
        var list = new ToDoListEntity
        {
            Name = newToDo.Name,
            Description = newToDo.Description
        };
        await _context.Lists.InsertOneAsync(list);
        return await GetDetail(list.Id);
    }

    public async Task<ToDoListDetailDto?> UpdateExisting(int id, UpdateToDoListDto toDo)
    {
        var update = Builders<ToDoListEntity>
            .Update
            .Set(x => x.Name, toDo.Name)
            .Set(x => x.Description, toDo.Description);
        var result = await _context.Lists.UpdateOneAsync(x => x.Id == id, update);
        return result is {MatchedCount: 0}
            ? null
            : await GetDetail(id);
    }

    public async Task<bool> DeleteExisting(int id)
    {
        var result = await _context.Lists.DeleteOneAsync(x => x.Id == id);
        return result is not {DeletedCount: 0};
    }

    public async Task<ToDoListItemDto?> AddToDoListItem(int id, AddToDoListItemDto item)
    {
        var todoItem = new ToDoItemEntity
        {
            Description = item.Description
        };

        var update = Builders<ToDoListEntity>
            .Update
            .Push(x => x.Items, todoItem);

        var result = await _context.Lists.UpdateOneAsync(x => x.Id == id, update);
        return result is {MatchedCount: 0}
            ? null
            : new ToDoListItemDto {Id = todoItem.Id, Description = todoItem.Description};
    }

    public async Task<ToDoListItemDto?> UpdateToDoListItem(int todoListId, int itemId, AddToDoListItemDto item)
    {
        var filter =
            Builders<ToDoListEntity>.Filter.Eq(x => x.Id, todoListId)
            & Builders<ToDoListEntity>.Filter.ElemMatch(x => x.Items, x => x.Id == itemId);

        var update = Builders<ToDoListEntity>
            .Update
            // [-1] is translated to .$ which means an array item that was found with the filter elem match
            .Set(x => x.Items[-1].Description, item.Description);

        var result = await _context.Lists.UpdateOneAsync(filter, update);
        return result is {MatchedCount: 0}
            ? null
            : new ToDoListItemDto {Id = itemId, Description = item.Description};
    }

    public async Task<bool> DeleteToDoListItem(int todoListId, int itemId)
    {
        var update = Builders<ToDoListEntity>
            .Update
            .PullFilter(x => x.Items, x => x.Id == itemId);

        var result = await _context.Lists.UpdateOneAsync(x => x.Id == todoListId, update);
        return result is not {ModifiedCount: 0};
    }
}