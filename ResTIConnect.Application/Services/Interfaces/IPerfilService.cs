using System.Collections.Generic;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface IPerfilService
    {
        List<PerfilViewModel> GetAll();
        PerfilViewModel? GetById(int id);
        List<PerfilViewModel> GetByUserId(int userId);
        int Create(NewPerfilInputModel perfil);

        
        IEnumerable<PerfilViewModel> GetPerfis();
    }
}
