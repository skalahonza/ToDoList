using Microsoft.AspNetCore.Mvc;
using ToDoList.BL.DTO;

namespace ToDoList.API.Controllers;

public class TodoController : ApiController
{
    /// <summary>
    /// Get all To-Do lists.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet]
    public Task<ActionResult<List<ToDoListInfoDto>>> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get To-Do list detail.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("{id}")]
    public Task<ActionResult<ToDoListDetailDto>> GetDetail(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates new To-Do list.
    /// </summary>
    /// <param name="newToDo"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost]
    public Task<ActionResult<ToDoListDetailDto>> AddNew(CreateToDoListDto newToDo)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates existing To-Do list.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="toDo"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPut("{id}")]
    public Task<ActionResult<ToDoListDetailDto>> UpdateExisting(Guid id, UpdateToDoListDto toDo)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete existing To-Do list.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpDelete("{id}")]
    public Task<ActionResult<IActionResult>> DeleteExisting(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Add To-Do item to an existing To-Do list.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost("{id}/items")]
    public Task<ActionResult<ToDoListItemDto>> AddToDoListItem(Guid id, AddToDoListItemDto item)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update an existing To-Do item in an existing To-Do list.
    /// </summary>
    /// <param name="todoListId"></param>
    /// <param name="itemId"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPut("{todoListId}/items/{itemId}")]
    public Task<ActionResult<ToDoListItemDto>> UpdateToDoListItem(Guid todoListId, Guid itemId, AddToDoListItemDto item)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes existing To-Do item from an existing To-Do list.
    /// </summary>
    /// <param name="todoListId"></param>
    /// <param name="itemId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpDelete("{todoListId}/items/{itemId}")]
    public Task<IActionResult> DeleteToDoListItem(Guid todoListId, Guid itemId)
    {
        throw new NotImplementedException();
    }
}