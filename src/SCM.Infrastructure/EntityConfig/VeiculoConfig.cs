using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Infrastructure.EntityConfig
{
    public class VeiculoConfig : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            #region Configurando a entidade Veiculo com Fluent API
            builder.ToTable("Veiculo");
            builder.Property(x => x.Placa)
                .HasColumnType("varchar(10)");

            builder.Property(x => x.Renavam)
                .HasColumnType("varchar(15)");

            #endregion
        }
    }
}
