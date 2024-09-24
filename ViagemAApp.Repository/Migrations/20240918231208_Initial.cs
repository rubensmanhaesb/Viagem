using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViagemAApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_COMPANIA_AEREA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nm_compania_aerea = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COMPANIA_AEREA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROGRAMA_FIDELIDADE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nm_programa_fidelidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROGRAMA_FIDELIDADE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PARCERIA_FIDELIDADE",
                columns: table => new
                {
                    IdCompaniaAeria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProgramaFidelidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    qtd_cpfs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PARCERIA_FIDELIDADE", x => new { x.IdCompaniaAeria, x.IdProgramaFidelidade });
                    table.ForeignKey(
                        name: "FK_TB_PARCERIA_FIDELIDADE_TB_COMPANIA_AEREA_IdCompaniaAeria",
                        column: x => x.IdCompaniaAeria,
                        principalTable: "TB_COMPANIA_AEREA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_PARCERIA_FIDELIDADE_TB_PROGRAMA_FIDELIDADE_IdProgramaFidelidade",
                        column: x => x.IdProgramaFidelidade,
                        principalTable: "TB_PROGRAMA_FIDELIDADE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PARCERIA_FIDELIDADE_IdProgramaFidelidade",
                table: "TB_PARCERIA_FIDELIDADE",
                column: "IdProgramaFidelidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PARCERIA_FIDELIDADE");

            migrationBuilder.DropTable(
                name: "TB_COMPANIA_AEREA");

            migrationBuilder.DropTable(
                name: "TB_PROGRAMA_FIDELIDADE");
        }
    }
}
