using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surfs_Up_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForgorLeAdminBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                schema: "identity",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                schema: "identity",
                table: "AspNetUsers");
        }
    }
}
