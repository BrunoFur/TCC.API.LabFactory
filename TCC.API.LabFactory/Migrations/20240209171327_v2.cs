using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC.API.LabFactory.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Endereco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
