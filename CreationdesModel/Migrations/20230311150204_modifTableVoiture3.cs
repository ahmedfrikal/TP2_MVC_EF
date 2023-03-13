using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreationdesModel.Migrations
{
    /// <inheritdoc />
    public partial class modifTableVoiture3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "couleur",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "couleur",
                table: "Voitures");
        }
    }
}
