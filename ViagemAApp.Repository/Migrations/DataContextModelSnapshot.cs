﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViagemApp.Infra.Data.SqlServer.Context;

#nullable disable

namespace ViagemApp.Infra.Data.SqlServer.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ViagemApp.Domain.Entities.CompanhiaAerea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("nm_companhia_aerea");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("IX_Nome_Companhia_Aerea");

                    b.ToTable("TB_COMPANHIA_AEREA", (string)null);
                });

            modelBuilder.Entity("ViagemApp.Domain.Entities.ParceriaFidelidade", b =>
                {
                    b.Property<Guid>("IdCompanhiaAeria")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProgramaFidelidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("QtdLimiteCpf")
                        .HasColumnType("int")
                        .HasColumnName("qtd_cpfs");

                    b.HasKey("IdCompanhiaAeria", "IdProgramaFidelidade");

                    b.HasIndex("IdProgramaFidelidade");

                    b.ToTable("TB_PARCERIA_FIDELIDADE", (string)null);
                });

            modelBuilder.Entity("ViagemApp.Domain.Entities.ProgramaFidelidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nm_programa_fidelidade");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasDatabaseName("IX_Nome_Programa_Fidelidade");

                    b.ToTable("TB_PROGRAMA_FIDELIDADE", (string)null);
                });

            modelBuilder.Entity("ViagemApp.Domain.Entities.ParceriaFidelidade", b =>
                {
                    b.HasOne("ViagemApp.Domain.Entities.CompanhiaAerea", "CompanhiaAeria")
                        .WithMany("ParceriaFidelidade")
                        .HasForeignKey("IdCompanhiaAeria")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ViagemApp.Domain.Entities.ProgramaFidelidade", "ProgramaFidelidade")
                        .WithMany("ParceriaFidelidade")
                        .HasForeignKey("IdProgramaFidelidade")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CompanhiaAeria");

                    b.Navigation("ProgramaFidelidade");
                });

            modelBuilder.Entity("ViagemApp.Domain.Entities.CompanhiaAerea", b =>
                {
                    b.Navigation("ParceriaFidelidade");
                });

            modelBuilder.Entity("ViagemApp.Domain.Entities.ProgramaFidelidade", b =>
                {
                    b.Navigation("ParceriaFidelidade");
                });
#pragma warning restore 612, 618
        }
    }
}
