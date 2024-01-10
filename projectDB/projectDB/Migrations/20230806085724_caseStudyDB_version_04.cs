using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectDB.Migrations
{
    public partial class caseStudyDB_version_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImgUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImgUrl",
                table: "Products");
        }
    }
}
