using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class updated_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "NonLiquidAssets",
                table: "NetWorthReports",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NonLiquidAssets",
                table: "NetWorthReports");
        }
    }
}
