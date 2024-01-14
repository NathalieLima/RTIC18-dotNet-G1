using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CleanArchitecture.Application.UseCases.CreateUser;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
         _mediator = mediator;   
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var userId = await _mediator.Send(request);
            return Ok(userId);
        }
    }
}