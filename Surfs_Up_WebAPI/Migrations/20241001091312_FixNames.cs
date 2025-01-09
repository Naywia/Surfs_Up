using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surfs_Up_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEquipment_Equipments_EquipmentID",
                table: "BookingEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSuit_Suits_SuitsID",
                table: "BookingSuit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suits",
                table: "Suits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.RenameTable(
                name: "Suits",
                newName: "Suit");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "Equipment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suit",
                table: "Suit",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEquipment_Equipment_EquipmentID",
                table: "BookingEquipment",
                column: "EquipmentID",
                principalTable: "Equipment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSuit_Suit_SuitsID",
                table: "BookingSuit",
                column: "SuitsID",
                principalTable: "Suit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEquipment_Equipment_EquipmentID",
                table: "BookingEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSuit_Suit_SuitsID",
                table: "BookingSuit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suit",
                table: "Suit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment");

            migrationBuilder.RenameTable(
                name: "Suit",
                newName: "Suits");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "Equipments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suits",
                table: "Suits",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEquipment_Equipments_EquipmentID",
                table: "BookingEquipment",
                column: "EquipmentID",
                principalTable: "Equipments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSuit_Suits_SuitsID",
                table: "BookingSuit",
                column: "SuitsID",
                principalTable: "Suits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
