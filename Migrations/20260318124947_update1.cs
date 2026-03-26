using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropManageX.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Renewals_Contracts_ContractID",
                table: "Renewals");

            migrationBuilder.AlterColumn<int>(
                name: "ContractID",
                table: "Renewals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Renewals_Contracts_ContractID",
                table: "Renewals",
                column: "ContractID",
                principalTable: "Contracts",
                principalColumn: "ContractID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Renewals_Contracts_ContractID",
                table: "Renewals");

            migrationBuilder.AlterColumn<int>(
                name: "ContractID",
                table: "Renewals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Renewals_Contracts_ContractID",
                table: "Renewals",
                column: "ContractID",
                principalTable: "Contracts",
                principalColumn: "ContractID");
        }
    }
}
