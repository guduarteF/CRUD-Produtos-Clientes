using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DropShipping.Migrations
{
    /// <inheritdoc />
    public partial class CriandoVinculoUsuarioNaContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UsuarioId",
                table: "Products",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Usuarios_UsuarioId",
                table: "Products",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Usuarios_UsuarioId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UsuarioId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Products");
        }
    }
}
