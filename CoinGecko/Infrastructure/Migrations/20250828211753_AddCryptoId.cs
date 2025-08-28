using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCryptoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoHistory",
                table: "CryptoHistory");

            migrationBuilder.AlterColumn<string>(
                name: "CryptoId",
                table: "CryptoHistory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CryptoHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoHistory",
                table: "CryptoHistory",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoHistory",
                table: "CryptoHistory");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CryptoHistory");

            migrationBuilder.AlterColumn<string>(
                name: "CryptoId",
                table: "CryptoHistory",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoHistory",
                table: "CryptoHistory",
                column: "CryptoId");
        }
    }
}
