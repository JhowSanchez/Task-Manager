using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoWEB.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationAddForeignKeyParaTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prioridadade",
                table: "Tarefas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ID_Usuario",
                table: "Tarefas",
                column: "ID_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_ID_Usuario",
                table: "Tarefas",
                column: "ID_Usuario",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_ID_Usuario",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ID_Usuario",
                table: "Tarefas");

            migrationBuilder.AlterColumn<int>(
                name: "Prioridadade",
                table: "Tarefas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
