using MongoDB.Driver;
using ToDoList.Mongo.Entities;

namespace ToDoList.Mongo;

public class ToDoMongoDbContext
{
    public ToDoMongoDbContext(IMongoClient client)
    {
        var database = client.GetDatabase("todo");
        Lists = database.GetCollection<ToDoListEntity>("lists");
    }

    public IMongoCollection<ToDoListEntity> Lists { get; }
}