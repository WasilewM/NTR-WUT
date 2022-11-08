using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcLibrary.Migrations
{
    public partial class AddedBookOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookOrderStatus = table.Column<decimal>(type: "decimal(2,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookOrder", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookOrder");
        }
    }
}
