using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL6.Hreo.Migrations
{
    public partial class Edited_UserResume_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResumes_FileInformations_FileInformationId",
                schema: "user",
                table: "UserResumes");

            migrationBuilder.DropColumn(
                name: "FileId",
                schema: "user",
                table: "UserResumes");

            migrationBuilder.AlterColumn<Guid>(
                name: "FileInformationId",
                schema: "user",
                table: "UserResumes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserResumes_FileInformations_FileInformationId",
                schema: "user",
                table: "UserResumes",
                column: "FileInformationId",
                principalSchema: "file",
                principalTable: "FileInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResumes_FileInformations_FileInformationId",
                schema: "user",
                table: "UserResumes");

            migrationBuilder.AlterColumn<Guid>(
                name: "FileInformationId",
                schema: "user",
                table: "UserResumes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                schema: "user",
                table: "UserResumes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
