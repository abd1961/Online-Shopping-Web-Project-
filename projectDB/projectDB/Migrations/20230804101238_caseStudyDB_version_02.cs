using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectDB.Migrations
{
    public partial class caseStudyDB_version_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavOrderItems_Products_FavouriteId",
                table: "FavOrderItems");

            migrationBuilder.RenameColumn(
                name: "FavouriteId",
                table: "FavOrderItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_FavOrderItems_FavouriteId",
                table: "FavOrderItems",
                newName: "IX_FavOrderItems_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavOrderItems_Products_ProductId",
                table: "FavOrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavOrderItems_Products_ProductId",
                table: "FavOrderItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "FavOrderItems",
                newName: "FavouriteId");

            migrationBuilder.RenameIndex(
                name: "IX_FavOrderItems_ProductId",
                table: "FavOrderItems",
                newName: "IX_FavOrderItems_FavouriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavOrderItems_Products_FavouriteId",
                table: "FavOrderItems",
                column: "FavouriteId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
