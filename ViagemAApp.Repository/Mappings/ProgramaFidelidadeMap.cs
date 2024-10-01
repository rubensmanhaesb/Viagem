using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViagemApp.Domain.Entities;

namespace ViagemAApp.Repository.Mappings
{
    public class ProgramaFidelidadeMap : IEntityTypeConfiguration<ProgramaFidelidade>
    {
        public void Configure(EntityTypeBuilder<ProgramaFidelidade> builder)
        {
            builder.ToTable("TB_PROGRAMA_FIDELIDADE");
            //pk
            builder.HasKey(p => p.Id);

            //mapeamento do campo
            builder.Property(p => p.Nome)
                .HasColumnName("nm_programa_fidelidade")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(c => c.Nome)
                            .IsUnique()
                            .HasDatabaseName("IX_Nome_Programa_Fidelidade");

        }
    }
}
