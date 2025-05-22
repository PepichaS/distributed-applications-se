using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.Data.Migrations
{
    public partial class addvt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the VehicleTypes table
            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            // Add the VehicleTypeId column to the Vehicles table
            migrationBuilder.AddColumn<string>(
                name: "VehicleTypeId",
                table: "Vehicles",
                nullable: true);

            // Add a foreign key constraint between Vehicles and VehicleTypes
            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the foreign key and column from the Vehicles table
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Vehicles");

            // Drop the VehicleTypes table
            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
