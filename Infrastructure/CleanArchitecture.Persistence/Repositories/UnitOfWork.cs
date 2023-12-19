using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;

namespace CleanArchitecture.Persistence.Repositories;
    //A principal responsabilidade dessa classe é gerenciar a transacao e o commit de operacoes no contexto de banco de dados
   public class UnitOfWork : IUnitOfWork
   {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);// Vai esperar ate que todas as alteracoes sejam confirmadas no banco antes de retornar
        }
    }      
