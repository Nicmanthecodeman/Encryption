using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Encryption.DataAccess.Migrations
{
    public partial class AddedAttachmentsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "files");

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "auth",
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ApplicationUserId",
                schema: "files",
                table: "Attachments",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "files");
        }
    }
}
