
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface IPerfilService
    {
        
        public List<PerfilViewModel> GetAll();
        public PerfilViewModel? GetById(int id);
        public List<PerfilViewModel> GetByUserId(int userId);//usuários com um determinado perfil
        public int Create(NewPerfilInputModel perfil);
    }
}