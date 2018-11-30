using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Infrastructure.EntityConfig
{
    public class MarcaConfig : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            #region Configurando a entidade Marca com Fluent API
                 builder.Property(x => x.Descricao)
                .HasColumnType("varchar(30)");
            #endregion
        }
    }
}
