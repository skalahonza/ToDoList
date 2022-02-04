namespace ToDoList.Mongo.Entities;

public abstract class AppEntity
{
    // Don't do this in production - for DEMO purpose only

    private static readonly Random Random = new();

    public int Id { get; set; } = Random.Next();
}