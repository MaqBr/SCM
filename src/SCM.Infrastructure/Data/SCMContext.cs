using Microsoft.EntityFrameworkCore;
using SCM.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Infrastructure.Data
{
    public class SCMContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Multa> Multas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BdSCM;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>().ToTable("Veiculo");
            modelBuilder.Entity<Multa>().ToTable("Infracao");

            #region Configurando a entidade Endereço com Fluent API
            modelBuilder.Entity<Endereco>()
                .Property(x => x.Rua)
                .HasColumnType("varchar(200)");

            modelBuilder.Entity<Endereco>()
                .Property(x => x.CEP)
                .HasColumnType("varchar(9)");

            modelBuilder.Entity<Endereco>()
                .Property(x => x.Logradouro)
                .HasColumnType("varchar(400)");
            #endregion
        }
    }
}
