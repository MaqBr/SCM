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

            modelBuilder.Entity<AcessorioVeiculo>()
                .HasKey(ch=> new { ch.AcessorioId, ch.VeiculoId });


            #region propagação de dados das entidades

            modelBuilder.Entity<Marca>()
                .HasData(

                new Marca { Id = 1, Descricao = "VW" },
                new Marca { Id = 2, Descricao = "FIAT" },
                new Marca { Id = 3, Descricao = "Ford" }

                );

            #endregion
            
            #region Configurando a entidade Endereco com Fluent API
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

            #region Configurando a entidade Veiculo com Fluent API
            modelBuilder.Entity<Veiculo>().ToTable("Veiculo");
            modelBuilder.Entity<Veiculo>()
                .Property(x => x.Placa)
                .HasColumnType("varchar(10)");

            modelBuilder.Entity<Veiculo>()
                .Property(x => x.Renavam)
                .HasColumnType("varchar(15)");

            #endregion

            #region Configurando a entidade Proprietario com Fluent API
            modelBuilder.Entity<Proprietario>()
                .Property(x => x.Nome)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Proprietario>()
                .Property(x => x.Email)
                .HasColumnType("varchar(100)");

            #endregion

            #region Configurando a entidade Marca com Fluent API
            modelBuilder.Entity<Marca>()
                .Property(x => x.Descricao)
                .HasColumnType("varchar(30)");
            #endregion

            #region Configurando a entidade Multa com Fluent API
            modelBuilder.Entity<Multa>().ToTable("Infracao");
            #endregion
        }
    }
}
