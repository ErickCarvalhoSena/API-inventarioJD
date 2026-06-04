using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficinaJD.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTipoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "modelos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "modelos");
        }
    }
}
