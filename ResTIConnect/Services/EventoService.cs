using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Services
{
    public class EventoService
    {
        private readonly EventosDbContext _dbContext;

        public EventoService(EventosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Evento> ObterTodosEventos()
        {
            return _dbContext.Eventos.ToList();
        }

        public Evento ObterEventoPorId(int eventoId)
        {
            return _dbContext.Eventos.Find(eventoId);
        }

        public void AdicionarEvento(Evento evento)
        {
            _dbContext.Eventos.Add(evento);
            _dbContext.SaveChanges();
        }

        public void AtualizarEvento(Evento evento)
        {
            _dbContext.Eventos.Update(evento);
            _dbContext.SaveChanges();
        }

        public void RemoverEvento(int eventoId)
        {
            var evento = _dbContext.Eventos.Find(eventoId);
            if (evento != null)
            {
                _dbContext.Eventos.Remove(evento);
                _dbContext.SaveChanges();
            }
        }
    }

}
