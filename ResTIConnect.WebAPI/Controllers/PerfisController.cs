using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfisController : ControllerBase
    {
        private readonly IPerfilService _perfilService;

        public PerfisController(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PerfilViewModel>> GetPerfis()
        {
            var perfis = _perfilService.GetPerfis();
            return Ok(perfis);
        }

        [HttpGet("{id}")]
        public ActionResult<PerfilViewModel> GetPerfilById(int id)
        {
            var perfil = _perfilService.GetById(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return Ok(perfil);
        }

        [HttpPost]
        public ActionResult<int> CreatePerfil(NewPerfilInputModel newPerfil)
        {
            var perfilId = _perfilService.Create(newPerfil);
            return CreatedAtAction(nameof(GetPerfilById), new { id = perfilId }, perfilId);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerfil(int id, NewPerfilInputModel updatedPerfil)
        {
            var existingPerfil = _perfilService.GetById(id);
            if (existingPerfil == null)
            {
                return NotFound();
            }

            existingPerfil.Descricao = updatedPerfil.Descricao;
            existingPerfil.Permissoes = updatedPerfil.Permissoes;


            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerfil(int id)
        {
            var perfil = _perfilService.GetById(id);
            if (perfil == null)
            {
                return NotFound();
            }


            return NoContent();
        }
    }
}
