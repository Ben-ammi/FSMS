using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSMS.Migrations
{
    /// <inheritdoc />
    public partial class ThirdUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocations_Users_UserId",
                schema: "User",
                table: "Allocations");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "User",
                table: "Allocations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocations_Users_UserId",
                schema: "User",
                table: "Allocations",
                column: "UserId",
                principalSchema: "User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocations_Users_UserId",
                schema: "User",
                table: "Allocations");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "User",
                table: "Allocations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocations_Users_UserId",
                schema: "User",
                table: "Allocations",
                column: "UserId",
                principalSchema: "User",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
