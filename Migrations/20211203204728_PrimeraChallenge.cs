using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge.Migrations
{
    public partial class PrimeraChallenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Disney");

            migrationBuilder.CreateTable(
                name: "Generos",
                schema: "Disney",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personajes",
                schema: "Disney",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personajes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasSeries",
                schema: "Disney",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Calificaion = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeliculasSeries_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalSchema: "Disney",
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaSeriePersonaje",
                schema: "Disney",
                columns: table => new
                {
                    PeliculaSerieAsociadaId = table.Column<int>(type: "int", nullable: false),
                    PersonajesAsociadosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSeriePersonaje", x => new { x.PeliculaSerieAsociadaId, x.PersonajesAsociadosId });
                    table.ForeignKey(
                        name: "FK_PeliculaSeriePersonaje_PeliculasSeries_PeliculaSerieAsociadaId",
                        column: x => x.PeliculaSerieAsociadaId,
                        principalSchema: "Disney",
                        principalTable: "PeliculasSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaSeriePersonaje_Personajes_PersonajesAsociadosId",
                        column: x => x.PersonajesAsociadosId,
                        principalSchema: "Disney",
                        principalTable: "Personajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaSeriePersonaje_PersonajesAsociadosId",
                schema: "Disney",
                table: "PeliculaSeriePersonaje",
                column: "PersonajesAsociadosId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasSeries_GeneroId",
                schema: "Disney",
                table: "PeliculasSeries",
                column: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaSeriePersonaje",
                schema: "Disney");

            migrationBuilder.DropTable(
                name: "PeliculasSeries",
                schema: "Disney");

            migrationBuilder.DropTable(
                name: "Personajes",
                schema: "Disney");

            migrationBuilder.DropTable(
                name: "Generos",
                schema: "Disney");
        }
    }
}
