using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.ViewModel;

namespace TechMed.Aplication.Services.Interfaces
{
    public interface IMedicoService
    {
        
      public List<MedicoViewModel> GetAll();
      public MedicoViewModel? GetById(int id);
      public MedicoViewModel? GetByCrm(string crm);
      public int Create(NewMedicoInputModel medico);
      public void Update(int id, NewMedicoInputModel medico);
      public void Delete(int id);
    }
}