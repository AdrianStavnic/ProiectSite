using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectSite.Migrations
{
    public partial class VacationCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Vacation");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Vacation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_CategoryID",
                table: "Vacation",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacation_Category_CategoryID",
                table: "Vacation",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacation_Category_CategoryID",
                table: "Vacation");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Vacation_CategoryID",
                table: "Vacation");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Vacation");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Vacation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
