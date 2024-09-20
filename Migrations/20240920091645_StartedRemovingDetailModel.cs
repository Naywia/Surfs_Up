using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfsUp.Migrations
{
    /// <inheritdoc />
    public partial class StartedRemovingDetailModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addon_DetailModel_DetailModelID",
                table: "Addon");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_DetailModel_EquipmentID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_DetailModel_DetailModelID",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Suits_DetailModel_DetailModelID",
                table: "Suits");

            migrationBuilder.DropTable(
                name: "DetailModel");

            migrationBuilder.DropIndex(
                name: "IX_Suits_DetailModelID",
                table: "Suits");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_DetailModelID",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Booking_EquipmentID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Addon_DetailModelID",
                table: "Addon");

            migrationBuilder.DropColumn(
                name: "DetailModelID",
                table: "Suits");

            migrationBuilder.DropColumn(
                name: "DetailModelID",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "EquipmentID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DetailModelID",
                table: "Addon");

            migrationBuilder.AddColumn<string>(
                name: "BookingModelID",
                table: "Suits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingModelID",
                table: "Equipments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingModelID",
                table: "Addon",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suits_BookingModelID",
                table: "Suits",
                column: "BookingModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_BookingModelID",
                table: "Equipments",
                column: "BookingModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Addon_BookingModelID",
                table: "Addon",
                column: "BookingModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addon_Booking_BookingModelID",
                table: "Addon",
                column: "BookingModelID",
                principalTable: "Booking",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Booking_BookingModelID",
                table: "Equipments",
                column: "BookingModelID",
                principalTable: "Booking",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suits_Booking_BookingModelID",
                table: "Suits",
                column: "BookingModelID",
                principalTable: "Booking",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addon_Booking_BookingModelID",
                table: "Addon");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Booking_BookingModelID",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Suits_Booking_BookingModelID",
                table: "Suits");

            migrationBuilder.DropIndex(
                name: "IX_Suits_BookingModelID",
                table: "Suits");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_BookingModelID",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Addon_BookingModelID",
                table: "Addon");

            migrationBuilder.DropColumn(
                name: "BookingModelID",
                table: "Suits");

            migrationBuilder.DropColumn(
                name: "BookingModelID",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "BookingModelID",
                table: "Addon");

            migrationBuilder.AddColumn<int>(
                name: "DetailModelID",
                table: "Suits",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetailModelID",
                table: "Equipments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentID",
                table: "Booking",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetailModelID",
                table: "Addon",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetailModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailModel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suits_DetailModelID",
                table: "Suits",
                column: "DetailModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_DetailModelID",
                table: "Equipments",
                column: "DetailModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_EquipmentID",
                table: "Booking",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Addon_DetailModelID",
                table: "Addon",
                column: "DetailModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addon_DetailModel_DetailModelID",
                table: "Addon",
                column: "DetailModelID",
                principalTable: "DetailModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_DetailModel_EquipmentID",
                table: "Booking",
                column: "EquipmentID",
                principalTable: "DetailModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_DetailModel_DetailModelID",
                table: "Equipments",
                column: "DetailModelID",
                principalTable: "DetailModel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suits_DetailModel_DetailModelID",
                table: "Suits",
                column: "DetailModelID",
                principalTable: "DetailModel",
                principalColumn: "ID");
        }
    }
}
