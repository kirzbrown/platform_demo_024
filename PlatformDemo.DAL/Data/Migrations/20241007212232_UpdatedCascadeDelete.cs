using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformDemo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_ServicePlans_ServicePlanId",
                table: "TimeSheets");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_ServicePlans_ServicePlanId",
                table: "TimeSheets",
                column: "ServicePlanId",
                principalTable: "ServicePlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSheets_ServicePlans_ServicePlanId",
                table: "TimeSheets");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSheets_ServicePlans_ServicePlanId",
                table: "TimeSheets",
                column: "ServicePlanId",
                principalTable: "ServicePlans",
                principalColumn: "Id");
        }
    }
}
