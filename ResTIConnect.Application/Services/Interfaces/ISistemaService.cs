
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface ISistemaService
    {
        
        public List<SistemaViewModel> GetAll();
        public SistemaViewModel? GetById(int id);
        public List<SistemaViewModel> GetByUserId(int userId);//sistemas com alguma relação com um determinado usuário
        public List<SistemaViewModel> GetByEventoPeriodos(int eventoId, DateTime inicio);//sistemas onde ocorreram um determinado evento a partir de uma data até a atual  
        public int Create(NewSistemaInputModel sistema);
    }
}