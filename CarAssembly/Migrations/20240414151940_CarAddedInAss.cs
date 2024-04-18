using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAssembly.Migrations
{
    /// <inheritdoc />
    public partial class CarAddedInAss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Assemblies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assemblies_CarId",
                table: "Assemblies",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assemblies_Cars_CarId",
                table: "Assemblies",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assemblies_Cars_CarId",
                table: "Assemblies");

            migrationBuilder.DropIndex(
                name: "IX_Assemblies_CarId",
                table: "Assemblies");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Assemblies");
        }
    }
}
