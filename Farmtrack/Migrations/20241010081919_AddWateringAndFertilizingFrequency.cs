using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farmtrack.Migrations
{
    /// <inheritdoc />
    public partial class AddWateringAndFertilizingFrequency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FertilizingFrequencyDays",
                table: "Crop",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WateringFrequencyDays",
                table: "Crop",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FertilizingFrequencyDays",
                table: "Crop");

            migrationBuilder.DropColumn(
                name: "WateringFrequencyDays",
                table: "Crop");
        }
    }
}
