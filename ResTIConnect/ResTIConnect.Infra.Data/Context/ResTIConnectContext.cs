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

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            base.OnConfiguring(optionsBuilder);
            var connectionString = "server=localhost;user=dotnet;password=tic2023;database=resticonnect;";
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

            base.OnModelCreating(modelBuilder);
        }

    }
}