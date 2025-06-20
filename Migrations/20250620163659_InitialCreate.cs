using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiarioDeSintomas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiarioSintomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Atividade = table.Column<string>(type: "TEXT", nullable: false),
                    Sintoma = table.Column<string>(type: "TEXT", nullable: false),
                    Duracao = table.Column<string>(type: "TEXT", nullable: false),
                    PressaoArterial = table.Column<string>(type: "TEXT", nullable: false),
                    OutrosSintomas = table.Column<string>(type: "TEXT", nullable: false),
                    Medicamentos = table.Column<string>(type: "TEXT", nullable: false),
                    AlimentacaoHidratacao = table.Column<string>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiarioSintomas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiarioSintomas");
        }
    }
}
