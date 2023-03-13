using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreationdesModel.Migrations
{
    /// <inheritdoc />
    public partial class ModifrTabl39 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "prix_jour",
                table: "locations",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prix_jour",
                table: "locations");
        }
    }
}
