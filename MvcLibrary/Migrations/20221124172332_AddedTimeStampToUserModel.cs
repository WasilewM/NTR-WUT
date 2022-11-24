using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcLibrary.Migrations
{
    public partial class AddedTimeStampToUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "User",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "User");
        }
    }
}
