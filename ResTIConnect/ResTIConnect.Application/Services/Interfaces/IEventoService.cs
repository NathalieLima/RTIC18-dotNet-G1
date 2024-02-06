
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Application.Services.Interfaces
{
    public interface IEventoService
    {
        
        public List<EventoViewModel> GetAll();
        public EventoViewModel? GetById(int id);
        public int Create(NewEventoInputModel evento);
    }
}