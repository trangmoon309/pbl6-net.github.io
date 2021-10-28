using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL6.Hreo.Migrations
{
    public partial class Add_References_For_Posts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostID",
                schema: "post",
                table: "InvitationPosts",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "ApplicantID",
                schema: "post",
                table: "InvitationPosts",
                newName: "ApplicantId");

            migrationBuilder.RenameColumn(
                name: "PostID",
                schema: "post",
                table: "InterestedPosts",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "ApplicantID",
                schema: "post",
                table: "InterestedPosts",
                newName: "ApplicantId");

            migrationBuilder.RenameColumn(
                name: "TestID",
                schema: "post",
                table: "ApplicantPosts",
                newName: "TestId");

            migrationBuilder.RenameColumn(
                name: "PostID",
                schema: "post",
                table: "ApplicantPosts",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "ApplicantID",
                schema: "post",
                table: "ApplicantPosts",
                newName: "ApplicantId");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                schema: "post",
                table: "InvitationPosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                schema: "post",
                table: "InterestedPosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                schema: "post",
                table: "ApplicantPosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvitationPosts_ApplicationId",
                schema: "post",
                table: "InvitationPosts",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationPosts_PostId",
                schema: "post",
                table: "InvitationPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestedPosts_ApplicationId",
                schema: "post",
                table: "InterestedPosts",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestedPosts_PostId",
                schema: "post",
                table: "InterestedPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPosts_ApplicationId",
                schema: "post",
                table: "ApplicantPosts",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPosts_PostId",
                schema: "post",
                table: "ApplicantPosts",
                column: "PostId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantPosts_Posts_PostId",
                schema: "post",
                table: "ApplicantPosts",
                column: "PostId",
                principalSchema: "post",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantPosts_UserInformations_ApplicationId",
                schema: "post",
                table: "ApplicantPosts",
                column: "ApplicationId",
                principalSchema: "user",
                principalTable: "UserInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestedPosts_Posts_PostId",
                schema: "post",
                table: "InterestedPosts",
                column: "PostId",
                principalSchema: "post",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestedPosts_UserInformations_ApplicationId",
                schema: "post",
                table: "InterestedPosts",
                column: "ApplicationId",
                principalSchema: "user",
                principalTable: "UserInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvitationPosts_Posts_PostId",
                schema: "post",
                table: "InvitationPosts",
                column: "PostId",
                principalSchema: "post",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvitationPosts_UserInformations_ApplicationId",
                schema: "post",
                table: "InvitationPosts",
                column: "ApplicationId",
                principalSchema: "user",
                principalTable: "UserInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantPosts_HreoTests_TestId",
                schema: "post",
                table: "ApplicantPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantPosts_Posts_PostId",
                schema: "post",
                table: "ApplicantPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantPosts_UserInformations_ApplicationId",
                schema: "post",
                table: "ApplicantPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestedPosts_Posts_PostId",
                schema: "post",
                table: "InterestedPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestedPosts_UserInformations_ApplicationId",
                schema: "post",
                table: "InterestedPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_InvitationPosts_Posts_PostId",
                schema: "post",
                table: "InvitationPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_InvitationPosts_UserInformations_ApplicationId",
                schema: "post",
                table: "InvitationPosts");

            migrationBuilder.DropIndex(
                name: "IX_InvitationPosts_ApplicationId",
                schema: "post",
                table: "InvitationPosts");

            migrationBuilder.DropIndex(
                name: "IX_InvitationPosts_PostId",
                schema: "post",
                table: "InvitationPosts");

            migrationBuilder.DropIndex(
                name: "IX_InterestedPosts_ApplicationId",
                schema: "post",
                table: "InterestedPosts");

            migrationBuilder.DropIndex(
                name: "IX_InterestedPosts_PostId",
                schema: "post",
                table: "InterestedPosts");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantPosts_ApplicationId",
                schema: "post",
                table: "ApplicantPosts");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantPosts_PostId",
                schema: "post",
                table: "ApplicantPosts");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantPosts_TestId",
                schema: "post",
                table: "ApplicantPosts");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                schema: "post",
                table: "InvitationPosts");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                schema: "post",
                table: "InterestedPosts");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                schema: "post",
                table: "ApplicantPosts");

            migrationBuilder.RenameColumn(
                name: "PostId",
                schema: "post",
                table: "InvitationPosts",
                newName: "PostID");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                schema: "post",
                table: "InvitationPosts",
                newName: "ApplicantID");

            migrationBuilder.RenameColumn(
                name: "PostId",
                schema: "post",
                table: "InterestedPosts",
                newName: "PostID");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                schema: "post",
                table: "InterestedPosts",
                newName: "ApplicantID");

            migrationBuilder.RenameColumn(
                name: "TestId",
                schema: "post",
                table: "ApplicantPosts",
                newName: "TestID");

            migrationBuilder.RenameColumn(
                name: "PostId",
                schema: "post",
                table: "ApplicantPosts",
                newName: "PostID");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                schema: "post",
                table: "ApplicantPosts",
                newName: "ApplicantID");
        }
    }
}
