using Microsoft.EntityFrameworkCore;
using ViagemApp.Domain.Entities;

namespace ViagemApp.Infra.Data.SqlServer.Mappings
{
    public class CompanhiaAereaMap : IEntityTypeConfiguration<CompanhiaAerea>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CompanhiaAerea> builder)
        {
            builder.ToTable("TB_COMPANHIA_AEREA");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasColumnName("nm_companhia_aerea")
            .HasMaxLength(150).IsRequired();

            
            builder.HasIndex(c => c.Nome)
                            .IsUnique()
                            .HasDatabaseName("IX_Nome_Companhia_Aerea");
        }
    }
}
