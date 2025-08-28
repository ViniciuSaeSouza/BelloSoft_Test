using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CryptoHistory_v21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Change24hrPercentage",
                table: "CryptoHistory",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Change24hrPercentage",
                table: "CryptoHistory",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");
        }
    }
}
