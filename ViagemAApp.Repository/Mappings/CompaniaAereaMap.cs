using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemApp.Domain.Entities;

namespace ViagemAApp.Repository.Mappings
{
    public class CompaniaAereaMap : IEntityTypeConfiguration<CompaniaAerea>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CompaniaAerea> builder)
        {
            builder.ToTable("TB_COMPANIA_AEREA");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasColumnName("nm_compania_aerea")
            .HasMaxLength(150).IsRequired();

        }
    }
}
