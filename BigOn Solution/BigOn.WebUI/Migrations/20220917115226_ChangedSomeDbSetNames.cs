using Microsoft.EntityFrameworkCore.Migrations;

namespace BigOn.WebUI.Migrations
{
    public partial class ChangedSomeDbSetNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMaterial",
                table: "ProductMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "ProductSize",
                newName: "ProductSizes");

            migrationBuilder.RenameTable(
                name: "ProductMaterial",
                newName: "ProductMaterials");

            migrationBuilder.RenameTable(
                name: "ProductColor",
                newName: "ProductColors");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductSizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallName",
                table: "ProductSizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSizes",
                table: "ProductSizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMaterials",
                table: "ProductMaterials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColors",
                table: "ProductColors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSizes",
                table: "ProductSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMaterials",
                table: "ProductMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColors",
                table: "ProductColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "SmallName",
                table: "ProductSizes");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProductType");

            migrationBuilder.RenameTable(
                name: "ProductSizes",
                newName: "ProductSize");

            migrationBuilder.RenameTable(
                name: "ProductMaterials",
                newName: "ProductMaterial");

            migrationBuilder.RenameTable(
                name: "ProductColors",
                newName: "ProductColor");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductSize",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMaterial",
                table: "ProductMaterial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");
        }
    }
}
