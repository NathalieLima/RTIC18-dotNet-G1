using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.ViewModel;

namespace TechMed.Aplication.Services.Interfaces
{
    public interface IExameService
    {
        public List<ExameViewModel> GetAll();
        public ExameViewModel GetById(int id);
        public List<AtendimentoViewModel> GetByAtendimentoId(int id);
        public void Create(NewExameInputModel exame);

    }
}