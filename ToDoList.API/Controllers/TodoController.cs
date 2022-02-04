using Microsoft.AspNetCore.Mvc;
using ToDoList.BL;
using ToDoList.BL.DTO;

namespace ToDoList.API.Controllers;

public class TodoController : ApiController
{
    private readonly ITodoService _service;

    public TodoController(ITodoService service) =>
        _service = service;

    /// <summary>
    /// Get all To-Do lists.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet]
    public Task<List<ToDoListInfoDto>> GetAll() =>
        _service.GetAll();

    /// <summary>
    /// Get To-Do list detail.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ToDoListDetailDto>> GetDetail(int id)
    {
        var detail = await _service.GetDetail(id);
        return OkOrNotFound(detail);
    }

    /// <summary>
    /// Creates new To-Do list.
    /// </summary>
    /// <param name="newToDo"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ToDoListDetailDto>> AddNew(CreateToDoListDto newToDo)
    {
        var detail = await _service.AddNew(newToDo);
        return OkOrNotFound(detail);
    }

    /// <summary>
    /// Updates existing To-Do list.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="toDo"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ToDoListDetailDto>> UpdateExisting(int id, UpdateToDoListDto toDo)
    {
        var detail = await _service.UpdateExisting(id, toDo);
        return OkOrNotFound(detail);
    }

    /// <summary>
    /// Delete existing To-Do list.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteExisting(int id)
    {
        var result = await _service.DeleteExisting(id);
        return OkOrNotFound(result);
    }

    /// <summary>
    /// Add To-Do item to an existing To-Do list.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost("{id}/items")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ToDoListItemDto>> AddToDoListItem(int id, AddToDoListItemDto item)
    {
        var detail = await _service.AddToDoListItem(id, item);
        return OkOrNotFound(detail);
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ToDoListItemDto>> UpdateToDoListItem(int todoListId, int itemId,
        AddToDoListItemDto item)
    {
        var detail = await _service.UpdateToDoListItem(todoListId, itemId, item);
        return OkOrNotFound(detail);
    }

    /// <summary>
    /// Removes existing To-Do item from an existing To-Do list.
    /// </summary>
    /// <param name="todoListId"></param>
    /// <param name="itemId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpDelete("{todoListId}/items/{itemId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteToDoListItem(int todoListId, int itemId)
    {
        var result = await _service.DeleteToDoListItem(todoListId, itemId);
        return OkOrNotFound(result);
    }
}