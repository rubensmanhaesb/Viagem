using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViagemApp.Domain.Entities;

namespace ViagemAApp.Repository.Mappings
{
    public class ParceriaFidelidadeMap : IEntityTypeConfiguration<ParceriaFidelidade>
    {
        public void Configure(EntityTypeBuilder<ParceriaFidelidade> builder)
        {
            builder.ToTable("TB_PARCERIA_FIDELIDADE");


            // Chave composta
            builder.HasKey(le => new { le.IdCompanhiaAeria, le.IdProgramaFidelidade});

            // Configuração das propriedades
            builder.Property(le => le.QtdLimiteCpf)
                    .HasColumnName("qtd_cpfs")
                   .IsRequired(false);

            // Configuração das relações
            builder.HasOne(le => le.CompanhiaAeria)
                   .WithMany(a => a.ParceriaFidelidade)
                   .HasForeignKey(le => le.IdCompanhiaAeria)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(le => le.ProgramaFidelidade)
                   .WithMany(lp => lp.ParceriaFidelidade)
                   .HasForeignKey(le => le.IdProgramaFidelidade)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
