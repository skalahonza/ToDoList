namespace ToDoList.EF.Entities;

public class ToDoItemEntity : AppEntity
{
    public string Description { get; set; }
    public int ToDoListEntityId { get; set; }
}