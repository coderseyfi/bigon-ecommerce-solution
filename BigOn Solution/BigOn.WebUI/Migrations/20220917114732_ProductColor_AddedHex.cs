using Microsoft.EntityFrameworkCore.Migrations;

namespace BigOn.WebUI.Migrations
{
    public partial class ProductColor_AddedHex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hex",
                table: "ProductColor",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hex",
                table: "ProductColor");
        }
    }
}
