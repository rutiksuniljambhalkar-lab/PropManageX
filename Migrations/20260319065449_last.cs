using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropManageX.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorAssignments_MaintenanceRequests_RequestID",
                table: "VendorAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "RequestID",
                table: "VendorAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorAssignments_MaintenanceRequests_RequestID",
                table: "VendorAssignments",
                column: "RequestID",
                principalTable: "MaintenanceRequests",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorAssignments_MaintenanceRequests_RequestID",
                table: "VendorAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "RequestID",
                table: "VendorAssignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VendorAssignments_MaintenanceRequests_RequestID",
                table: "VendorAssignments",
                column: "RequestID",
                principalTable: "MaintenanceRequests",
                principalColumn: "RequestID");
        }
    }
}
