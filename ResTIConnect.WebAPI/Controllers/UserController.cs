using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Exceptions;

namespace ResTIConnect.WebAPI.Controllers
{
    
    [ApiController]
    [Route("/api/v0.1/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public List<UserViewModel> Users => _userService.GetAll();
        public UserController(IUserService service) => _userService = service;


        [HttpGet("users")]
        public IActionResult Get()
        {
            return Ok(Users);
        }

        [HttpGet("user/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }


        [HttpPost("user")]
        public IActionResult Post([FromBody] NewUserInputModel user)
        {
            _userService.Create(user);

            return CreatedAtAction(nameof(Get), user);

        }

        [HttpPut("user/{id}")]
        public IActionResult Put(int id, [FromBody] NewUserInputModel user)
        {
            if (_userService.GetById(id) == null)
                return NoContent();
            _userService.Update(id, user);
            return Ok(_userService.GetById(id));
        }

        [HttpDelete("user/{id}")]
        public IActionResult Delete(int id)
        {
            if (_userService.GetById(id) == null)
                return NoContent();
            _userService.Delete(id);
            return Ok();
        }
        
        [HttpPut("user/{userId}/perfil/{perfilId}")]
        public IActionResult AdicionaPerfilAoUser(int userId, int perfilId)
        {
            try
            {
                _userService.AdicionaPerfilAoUser(userId, perfilId);
                return Ok("Perfil adicionado ao usuário com sucesso");
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (SistemaNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }
    }
}