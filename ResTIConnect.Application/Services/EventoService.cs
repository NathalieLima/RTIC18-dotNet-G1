
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services
{
    public class EventoService : IEventoService
    {
        public int Create(NewEventoInputModel evento)
        {
            throw new NotImplementedException();
        }

        public List<EventoViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EventoViewModel? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}