using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DropShipping.Migrations
{
    /// <inheritdoc />
    public partial class scaffolding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Products",
                newName: "Name");
        }
    }
}
