using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllUserResponse>>>GetAll(CancellationToken cancellationToken)
    {
        var response = await  _mediator.Send(new GetAllUserRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}