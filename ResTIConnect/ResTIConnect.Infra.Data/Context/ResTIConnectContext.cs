using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;
namespace ResTIConnect.Infra.Data.Context
{
    public class ResTIConnectContext : DbContext
    {
        public DbSet<Logs> Logs { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Perfis> Perfis { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "server=localhost;user=dotnet;password=d@n!&L702203;database=resticonnect;";
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Logs>().ToTable("Logs").HasKey(m => m.LogId);
            modelBuilder.Entity<Logs>().Property(m => m.Tipo).IsRequired();
            modelBuilder.Entity<Logs>().Property(m => m.Descricao).IsRequired();
            modelBuilder.Entity<Logs>().Property(m => m.DataHoraEvento);
            modelBuilder.Entity<Logs>().Property(m => m.Entidade);
            modelBuilder.Entity<Logs>().Property(m => m.TuplaId);

            modelBuilder.Entity<User>().ToTable("Users").HasKey(m => m.UserId);
            modelBuilder.Entity<User>().Property(m => m.Name).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(m => m.Email).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<User>().Property(m => m.Password).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<User>().Property(m => m.Telefone).HasMaxLength(20);
            
            modelBuilder.Entity<Enderecos>().ToTable("Enderecos").HasKey(m => m.EnderecoId);
            modelBuilder.Entity<Enderecos>().Property(m => m.Logradouro).IsRequired();
            modelBuilder.Entity<Enderecos>().Property(m => m.Numero).IsRequired();
            modelBuilder.Entity<Enderecos>().Property(m => m.Cidade).IsRequired();
            modelBuilder.Entity<Enderecos>().Property(m => m.Complemento);
            modelBuilder.Entity<Enderecos>().Property(m => m.Bairro).IsRequired();
            modelBuilder.Entity<Enderecos>().Property(m => m.Estado).IsRequired();
            modelBuilder.Entity<Enderecos>().Property(m => m.Cep).IsRequired();
            modelBuilder.Entity<Enderecos>().Property(m => m.Pais).IsRequired();
            
            modelBuilder.Entity<Perfis>().ToTable("Perfis").HasKey(m => m.PerfilId);
            modelBuilder.Entity<Perfis>().Property(m => m.Descricao).IsRequired();
            modelBuilder.Entity<Perfis>().Property(m => m.Permissoes).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}