using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Persistence.Context{
        //Herdado do Entity Framework
        public class AppDbContext : DbContext{ 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        //cria a tabela
        public DbSet<User> Users {get; set;}
       
       //sobrescreve o metodo
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "server=localhost;user=User;password=d@n!&L702203;database=techmed";
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion);

        }
        //serve apenas para fazer a conexão com o banco de dados e criar a tabela
    }
} 