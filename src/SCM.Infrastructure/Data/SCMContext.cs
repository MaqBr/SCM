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
            modelBuilder.Entity<Veiculo>().ToTable("TbVeiculo");
            modelBuilder.Entity<Multa>().ToTable("TbInfracao");

        }
    }
}
