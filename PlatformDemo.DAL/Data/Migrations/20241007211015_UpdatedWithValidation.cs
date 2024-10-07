using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformDemo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedWithValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_ServicePlans_ServicePlanId",
                table: "Timesheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Timesheets",
                table: "Timesheets");

            migrationBuilder.RenameTable(
                name: "Timesheets",
                newName: "TimeSheets");

            migrationBuilder.RenameIndex(
                name: "IX_Timesheets_ServicePlanId",
                table: "TimeSheets",
                newName: "IX_TimeSheets_ServicePlanId");

            migrationBuilder.AlterColumn<int>(
                name: "ServicePlanId",
                table: "TimeSheets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TimeSheets",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSheets",
                table: "TimeSheets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_ServicePlans_ServicePlanId",
                table: "TimeSheets",
                column: "ServicePlanId",
                principalTable: "ServicePlans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_ServicePlans_ServicePlanId",
                table: "TimeSheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSheets",
                table: "TimeSheets");

            migrationBuilder.RenameTable(
                name: "TimeSheets",
                newName: "Timesheets");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSheets_ServicePlanId",
                table: "Timesheets",
                newName: "IX_Timesheets_ServicePlanId");

            migrationBuilder.AlterColumn<int>(
                name: "ServicePlanId",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Timesheets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Timesheets",
                table: "Timesheets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_ServicePlans_ServicePlanId",
                table: "Timesheets",
                column: "ServicePlanId",
                principalTable: "ServicePlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
