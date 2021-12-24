using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL6.Hreo.Migrations
{
    public partial class Added_Applicant_Tests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantPosts_HreoTests_TestId",
                schema: "post",
                table: "ApplicantPosts");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantPosts_TestId",
                schema: "post",
                table: "ApplicantPosts");

            migrationBuilder.DropColumn(
                name: "TestId",
                schema: "post",
                table: "ApplicantPosts");

            migrationBuilder.CreateTable(
                name: "ApplicantTestQuestions",
                schema: "test",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Choose = table.Column<int>(type: "integer", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantTestQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantTestQuestions_HreoTestQuestions_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalSchema: "test",
                        principalTable: "HreoTestQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantTestQuestions_HreoTests_TestId",
                        column: x => x.TestId,
                        principalSchema: "test",
                        principalTable: "HreoTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantTestQuestions_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantTestQuestions_UserInformations_ApplicantId",
                        column: x => x.ApplicantId,
                        principalSchema: "user",
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantTests",
                schema: "test",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    TestId = table.Column<Guid>(type: "uuid", nullable: false),
                    Result = table.Column<double>(type: "double precision", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantTests_HreoTests_TestId",
                        column: x => x.TestId,
                        principalSchema: "test",
                        principalTable: "HreoTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantTests_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantTests_UserInformations_ApplicantId",
                        column: x => x.ApplicantId,
                        principalSchema: "user",
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantTestQuestions_TestId",
                schema: "test",
                table: "ApplicantTestQuestions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantTestQuestions_TestQuestionId",
                schema: "test",
                table: "ApplicantTestQuestions",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantTests_ApplicantId",
                schema: "test",
                table: "ApplicantTests",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantTests_PostId",
                schema: "test",
                table: "ApplicantTests",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantTests_TestId",
                schema: "test",
                table: "ApplicantTests",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantTestQuestions",
                schema: "test");

            migrationBuilder.DropTable(
                name: "ApplicantTests",
                schema: "test");

            migrationBuilder.AddColumn<Guid>(
                name: "TestId",
                schema: "post",
                table: "ApplicantPosts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPosts_TestId",
                schema: "post",
                table: "ApplicantPosts",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantPosts_HreoTests_TestId",
                schema: "post",
                table: "ApplicantPosts",
                column: "TestId",
                principalSchema: "test",
                principalTable: "HreoTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
