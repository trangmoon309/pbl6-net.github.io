using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL6.Hreo.Migrations
{
    public partial class Edited_UserResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "user",
                table: "UserResumes");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "user",
                table: "UserResumes",
                newName: "ResumeName");

            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                schema: "user",
                table: "UserResumes",
                newName: "JobTitle");

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                schema: "user",
                table: "UserResumes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FileInformationId",
                schema: "user",
                table: "UserResumes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "user",
                table: "UserResumes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserResumes_FileInformationId",
                schema: "user",
                table: "UserResumes",
                column: "FileInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResumes_FileInformations_FileInformationId",
                schema: "user",
                table: "UserResumes",
                column: "FileInformationId",
                principalSchema: "file",
                principalTable: "FileInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResumes_FileInformations_FileInformationId",
                schema: "user",
                table: "UserResumes");

            migrationBuilder.DropIndex(
                name: "IX_UserResumes_FileInformationId",
                schema: "user",
                table: "UserResumes");

            migrationBuilder.DropColumn(
                name: "FileId",
                schema: "user",
                table: "UserResumes");

            migrationBuilder.DropColumn(
                name: "FileInformationId",
                schema: "user",
                table: "UserResumes");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "user",
                table: "UserResumes");

            migrationBuilder.RenameColumn(
                name: "ResumeName",
                schema: "user",
                table: "UserResumes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                schema: "user",
                table: "UserResumes",
                newName: "LogoUrl");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "user",
                table: "UserResumes",
                type: "text",
                nullable: true);
        }
    }
}
