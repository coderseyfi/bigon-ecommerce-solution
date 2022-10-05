using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BigOn.WebUI.Migrations
{
    public partial class SubscribesWithApproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Subscribes");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Subscribes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "Subscribes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Subscribes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Subscribes");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Subscribes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Subscribes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
