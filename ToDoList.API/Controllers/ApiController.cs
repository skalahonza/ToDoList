using Microsoft.AspNetCore.Mvc;

namespace ToDoList.API.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase
{
    protected ActionResult<T> OkOrNotFound<T>(T? content) =>
        content is null ? NotFound() : Ok(content);

    protected IActionResult OkOrNotFound(bool result) =>
        result ? Ok() : NotFound();
}