using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class firstDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Territories_Regions_RegionId1",
                table: "Territories");

            migrationBuilder.DropIndex(
                name: "IX_Territories_RegionId1",
                table: "Territories");

            migrationBuilder.DropColumn(
                name: "RegionId1",
                table: "Territories");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Territories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.CreateIndex(
                name: "IX_Territories_RegionId",
                table: "Territories",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Territories_Regions_RegionId",
                table: "Territories",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Territories_Regions_RegionId",
                table: "Territories");

            migrationBuilder.DropIndex(
                name: "IX_Territories_RegionId",
                table: "Territories");

            migrationBuilder.AlterColumn<short>(
                name: "RegionId",
                table: "Territories",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "RegionId1",
                table: "Territories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Territories_RegionId1",
                table: "Territories",
                column: "RegionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Territories_Regions_RegionId1",
                table: "Territories",
                column: "RegionId1",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
