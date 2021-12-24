using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL6.Hreo.Migrations
{
    public partial class Updated_Applicant_Test_Question : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantTestQuestions_HreoTests_TestId",
                schema: "test",
                table: "ApplicantTestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantTestQuestions_Posts_PostId",
                schema: "test",
                table: "ApplicantTestQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantTestQuestions_UserInformations_ApplicantId",
                schema: "test",
                table: "ApplicantTestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantTestQuestions_ApplicantId",
                schema: "test",
                table: "ApplicantTestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantTestQuestions_PostId",
                schema: "test",
                table: "ApplicantTestQuestions");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                schema: "test",
                table: "ApplicantTestQuestions");

            migrationBuilder.DropColumn(
                name: "PostId",
                schema: "test",
                table: "ApplicantTestQuestions");

            migrationBuilder.RenameColumn(
                name: "TestId",
                schema: "test",
                table: "ApplicantTestQuestions",
                newName: "ApplicantTestId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantTestQuestions_TestId",
                schema: "test",
                table: "ApplicantTestQuestions",
                newName: "IX_ApplicantTestQuestions_ApplicantTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantTestQuestions_ApplicantTests_ApplicantTestId",
                schema: "test",
                table: "ApplicantTestQuestions",
                column: "ApplicantTestId",
                principalSchema: "test",
                principalTable: "ApplicantTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantTestQuestions_ApplicantTests_ApplicantTestId",
                schema: "test",
                table: "ApplicantTestQuestions");

            migrationBuilder.RenameColumn(
                name: "ApplicantTestId",
                schema: "test",
                table: "ApplicantTestQuestions",
                newName: "TestId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantTestQuestions_ApplicantTestId",
                schema: "test",
                table: "ApplicantTestQuestions",
                newName: "IX_ApplicantTestQuestions_TestId");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicantId",
                schema: "test",
                table: "ApplicantTestQuestions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                schema: "test",
                table: "ApplicantTestQuestions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantTestQuestions_ApplicantId",
                schema: "test",
                table: "ApplicantTestQuestions",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantTestQuestions_PostId",
                schema: "test",
                table: "ApplicantTestQuestions",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantTestQuestions_HreoTests_TestId",
                schema: "test",
                table: "ApplicantTestQuestions",
                column: "TestId",
                principalSchema: "test",
                principalTable: "HreoTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantTestQuestions_Posts_PostId",
                schema: "test",
                table: "ApplicantTestQuestions",
                column: "PostId",
                principalSchema: "post",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantTestQuestions_UserInformations_ApplicantId",
                schema: "test",
                table: "ApplicantTestQuestions",
                column: "ApplicantId",
                principalSchema: "user",
                principalTable: "UserInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
