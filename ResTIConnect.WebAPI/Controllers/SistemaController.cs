using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class SistemaController : ControllerBase
    {
        
        private readonly ISistemaService _sistemaService;
        public List<SistemaViewModel> Sistemas => _sistemaService.GetAll();
        public SistemaController(ISistemaService sistemaService) => _sistemaService = sistemaService;

        [HttpGet("sistemas")]
        public IActionResult Get()
        {

            return Ok(Sistemas);
        }
        [HttpGet("sistema/{id}")]
        public IActionResult GetById(int id)
        {
            var sistema = _sistemaService.GetById(id);
            return Ok(sistema);
        }
        

        [HttpPost("sistema")]
        public IActionResult Post([FromBody] NewSistemaInputModel sistema)
        {
            _sistemaService.Create(sistema);

            return CreatedAtAction(nameof(Get), sistema);

        }
        [HttpGet("system/user/{id}")]// – sistemas com alguma relação com um determinado usuário 
        public IActionResult GetSistemasByUserId(int userId)
        {
            var sistemas = _sistemaService.GetUserById(userId);
            return Ok(sistemas);
        }
    }
}