using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.ViewModel;

namespace TechMed.Aplication.Services.Interfaces
{
    public interface IAtendimentoService
    {
        public List<AtendimentoViewModel> GetAll();
        public AtendimentoViewModel? GetById(int id);
        public List<AtendimentoViewModel> GetByPacienteId(int pacienteId);
        public List<AtendimentoViewModel> GetByMedicoId(int medicoId);
        public int Create(NewAtendimentoInputModel atendimento);
    }
}