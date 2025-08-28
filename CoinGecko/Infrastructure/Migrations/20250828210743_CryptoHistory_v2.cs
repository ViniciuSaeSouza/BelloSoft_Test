using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CryptoHistory_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Change24hr",
                table: "CryptoHistory");

            migrationBuilder.AddColumn<decimal>(
                name: "Change24hrPercentage",
                table: "CryptoHistory",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Change24hrPercentage",
                table: "CryptoHistory");

            migrationBuilder.AddColumn<decimal>(
                name: "Change24hr",
                table: "CryptoHistory",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
