using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL6.Hreo.Migrations
{
    public partial class Add_Reference_Test_TestQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TestId",
                schema: "test",
                table: "HreoTestQuestions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserInformations_BranchId",
                schema: "user",
                table: "UserInformations",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HreoTestQuestions_TestId",
                schema: "test",
                table: "HreoTestQuestions",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_HreoTestQuestions_HreoTests_TestId",
                schema: "test",
                table: "HreoTestQuestions",
                column: "TestId",
                principalSchema: "test",
                principalTable: "HreoTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInformations_Branches_BranchId",
                schema: "user",
                table: "UserInformations",
                column: "BranchId",
                principalSchema: "company",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HreoTestQuestions_HreoTests_TestId",
                schema: "test",
                table: "HreoTestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInformations_Branches_BranchId",
                schema: "user",
                table: "UserInformations");

            migrationBuilder.DropIndex(
                name: "IX_UserInformations_BranchId",
                schema: "user",
                table: "UserInformations");

            migrationBuilder.DropIndex(
                name: "IX_HreoTestQuestions_TestId",
                schema: "test",
                table: "HreoTestQuestions");

            migrationBuilder.DropColumn(
                name: "TestId",
                schema: "test",
                table: "HreoTestQuestions");
        }
    }
}
