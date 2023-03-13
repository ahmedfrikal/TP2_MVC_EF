using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreationdesModel.Migrations
{
    /// <inheritdoc />
    public partial class ModifrTabl33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assurances_Voitures_VoitureId",
                table: "assurances");

            migrationBuilder.RenameColumn(
                name: "VoitureId",
                table: "assurances",
                newName: "voitureID");

            migrationBuilder.RenameIndex(
                name: "IX_assurances_VoitureId",
                table: "assurances",
                newName: "IX_assurances_voitureID");

            migrationBuilder.AlterColumn<int>(
                name: "voitureID",
                table: "assurances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_assurances_Voitures_voitureID",
                table: "assurances",
                column: "voitureID",
                principalTable: "Voitures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assurances_Voitures_voitureID",
                table: "assurances");

            migrationBuilder.RenameColumn(
                name: "voitureID",
                table: "assurances",
                newName: "VoitureId");

            migrationBuilder.RenameIndex(
                name: "IX_assurances_voitureID",
                table: "assurances",
                newName: "IX_assurances_VoitureId");

            migrationBuilder.AlterColumn<int>(
                name: "VoitureId",
                table: "assurances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_assurances_Voitures_VoitureId",
                table: "assurances",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "Id");
        }
    }
}
