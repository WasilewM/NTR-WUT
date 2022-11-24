using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcLibrary.Migrations
{
    public partial class AddedTimeStampToBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "Book",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Book");
        }
    }
}
