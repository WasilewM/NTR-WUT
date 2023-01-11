using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTRLab4Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBookModelToContainUsernameInsteadOfUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Book");

            // migrationBuilder.AlterColumn<byte[]>(
            //     name: "TimeStamp",
            //     table: "Book",
            //     type: "rowversion",
            //     rowVersion: true,
            //     nullable: false,
            //     defaultValue: new byte[0],
            //     oldClrType: typeof(byte[]),
            //     oldType: "rowversion",
            //     oldRowVersion: true,
            //     oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Book");

            // migrationBuilder.AlterColumn<byte[]>(
            //     name: "TimeStamp",
            //     table: "Book",
            //     type: "rowversion",
            //     rowVersion: true,
            //     nullable: true,
            //     oldClrType: typeof(byte[]),
            //     oldType: "rowversion",
            //     oldRowVersion: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Book",
                type: "int",
                nullable: true);
        }
    }
}
