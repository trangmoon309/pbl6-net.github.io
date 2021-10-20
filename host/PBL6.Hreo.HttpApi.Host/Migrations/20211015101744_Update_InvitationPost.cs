using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL6.Hreo.Migrations
{
    public partial class Update_InvitationPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorID",
                schema: "post",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatorID",
                schema: "post",
                table: "InvitationPosts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorID",
                schema: "post",
                table: "Posts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorID",
                schema: "post",
                table: "InvitationPosts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
