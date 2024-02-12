using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.Services.Interfaces;
using TechMed.Aplication.ViewModel;
using TechMed.Dommain.Entities;
using TechMed.Dommain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Aplication.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly TechMedDbContext _context;
        public PacienteService(TechMedDbContext context)
        {
            _context = context;
        }
         private Paciente GetByDbId(int id)
        {
            var _paciente = _context.Pacientes.Find(id);

            if (_paciente is null)
                throw new PacienteNotFoundException();
            
            return _paciente;
        }
        public List<PacienteViewModel> GetAll()
        {
            var _pacientes = _context.Pacientes.Select(p => new PacienteViewModel
            {
                PacienteId = p.PacienteId,
                Nome = p.Nome
            }).ToList();
            return _pacientes;
        }
        public PacienteViewModel? GetById(int id)
        {
            var _paciente = GetByDbId(id);
            var PacienteViewModel = new PacienteViewModel
            {
                PacienteId = _paciente.PacienteId,
                Nome = _paciente.Nome
            };
            return PacienteViewModel;
        }
        
        public int Create(NewPacienteInputModel paciente)
        {
            var _paciente = new Paciente
            {
                Nome = paciente.Nome!
            };
            _context.Pacientes.Add(_paciente);

            _context.SaveChanges();

            return _paciente.PacienteId;
        }
        public void Update(int id, NewPacienteInputModel paciente)
        {
            var _paciente = GetByDbId(id);
            _paciente.Nome = paciente.Nome!;
            _context.Pacientes.Update(_paciente);
            _context.SaveChanges();

        }
        public void Delete(int id)
        {
            _context.Pacientes.Remove(GetByDbId(id));
            _context.SaveChanges();
        }
    }
}