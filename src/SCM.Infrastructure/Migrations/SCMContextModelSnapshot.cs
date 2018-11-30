﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCM.Infrastructure.Data;

namespace SCM.Infrastructure.Migrations
{
    [DbContext(typeof(SCMContext))]
    partial class SCMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Acessorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Acessorio");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.AcessorioVeiculo", b =>
                {
                    b.Property<int>("AcessorioId");

                    b.Property<int>("VeiculoId");

                    b.Property<int>("Id");

                    b.HasKey("AcessorioId", "VeiculoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("AcessorioVeiculo");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(400)");

                    b.Property<int>("ProprietarioId");

                    b.Property<string>("Rua")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ProprietarioId")
                        .IsUnique();

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Marca");

                    b.HasData(
                        new { Id = 1, Descricao = "VW" },
                        new { Id = 2, Descricao = "FIAT" },
                        new { Id = 3, Descricao = "Ford" }
                    );
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Multa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Pontuacao");

                    b.Property<decimal>("Valor");

                    b.Property<int?>("VeiculoId");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Infracao");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Proprietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Proprietario");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MarcaId");

                    b.Property<string>("Placa")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("ProprietarioId");

                    b.Property<string>("Renavam")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.AcessorioVeiculo", b =>
                {
                    b.HasOne("SCM.ApplicationCore.Entity.Acessorio", "Acessorio")
                        .WithMany("AcessoriosVeiculos")
                        .HasForeignKey("AcessorioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SCM.ApplicationCore.Entity.Veiculo", "Veiculo")
                        .WithMany("AcessoriosVeiculos")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Endereco", b =>
                {
                    b.HasOne("SCM.ApplicationCore.Entity.Proprietario", "Proprietario")
                        .WithOne("Endereco")
                        .HasForeignKey("SCM.ApplicationCore.Entity.Endereco", "ProprietarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Multa", b =>
                {
                    b.HasOne("SCM.ApplicationCore.Entity.Veiculo", "Veiculo")
                        .WithMany("Multas")
                        .HasForeignKey("VeiculoId");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Veiculo", b =>
                {
                    b.HasOne("SCM.ApplicationCore.Entity.Marca", "Marca")
                        .WithMany("Veiculos")
                        .HasForeignKey("MarcaId");

                    b.HasOne("SCM.ApplicationCore.Entity.Proprietario", "Proprietario")
                        .WithMany("Veiculos")
                        .HasForeignKey("ProprietarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
