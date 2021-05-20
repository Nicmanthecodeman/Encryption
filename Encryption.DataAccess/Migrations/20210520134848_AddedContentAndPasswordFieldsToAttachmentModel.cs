using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Encryption.DataAccess.Migrations
{
    public partial class AddedContentAndPasswordFieldsToAttachmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MimeType",
                schema: "files",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "files",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                schema: "files",
                table: "Attachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "files",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                schema: "files",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "files",
                table: "Attachments");

            migrationBuilder.AlterColumn<string>(
                name: "MimeType",
                schema: "files",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "files",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
