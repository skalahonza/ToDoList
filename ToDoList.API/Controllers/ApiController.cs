using Microsoft.AspNetCore.Mvc;

namespace ToDoList.API.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase
{
}