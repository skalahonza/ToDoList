namespace ToDoList.Mongo.Entities;

public class ToDoListEntity : AppEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public List<ToDoItemEntity> Items { get; set; } = new();
}