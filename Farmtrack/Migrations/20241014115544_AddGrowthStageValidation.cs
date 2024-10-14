using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmtrack.Migrations
{
    /// <inheritdoc />
    public partial class AddGrowthStageValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrowthStage",
                table: "Crop",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrowthStage",
                table: "Crop");
        }
    }
}
