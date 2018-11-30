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

            modelBuilder.Entity<Proprietario>()
                  .HasData(

                  new Proprietario { Id = 1, Nome = "Neemias", Email="neemias@teste.com" },
                  new Proprietario { Id = 2, Nome = "Marcio", Email = "marcio@teste.com" }

                  );

            modelBuilder.Entity<Veiculo>()
                  .HasData(

                  new Veiculo { Id = 1, Placa = "ABC-1234", Renavam = "12212121212", ProprietarioId = 1 },
                  new Veiculo { Id = 2, Placa = "ABC-1235", Renavam = "67676766767", ProprietarioId = 2 }


      );

            modelBuilder.Entity<Acessorio>()
                .HasData(

                new Acessorio { Id = 1, Descricao = "Roda esportiva" },
                new Acessorio { Id = 2, Descricao = "Aerofolio" },
                new Acessorio { Id = 3, Descricao = "Banco esportivo" }

                );

            modelBuilder.Entity<AcessorioVeiculo>()
                    .HasData(

                    new AcessorioVeiculo { Id = 1, VeiculoId = 1, AcessorioId = 1 },
                    new AcessorioVeiculo { Id = 2, VeiculoId = 2, AcessorioId = 1 },
                    new AcessorioVeiculo { Id = 3, VeiculoId = 2, AcessorioId = 2 },
                    new AcessorioVeiculo { Id = 4, VeiculoId = 1, AcessorioId = 2 }

                    );

            modelBuilder.Entity<Multa>()
                .HasData(

                    new Multa { Id = 1, Valor = 200, Pontuacao = 10, VeiculoId = 1 },
                    new Multa { Id = 2, Valor = 500, Pontuacao = 30, VeiculoId = 2 },
                    new Multa { Id = 3, Valor = 700, Pontuacao = 50, VeiculoId = 1 }

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
