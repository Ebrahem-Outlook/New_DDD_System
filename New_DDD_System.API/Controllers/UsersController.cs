using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace New_DDD_System.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public sealed class UsersController(ISender sender) : ControllerBase
{
    
}
