using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoWEB.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    DetalhesTarefa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataTarefa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prioridadade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tarefas_Usuarios_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ID_Usuario",
                table: "Tarefas",
                column: "ID_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
