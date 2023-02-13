using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatMesssage.Infrastructure.Database.Migrations.ChatMesssageMigrations
{
    public partial class AddProductAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Thumbnail_Extension",
                schema: "ChatMesssage",
                table: "Categories",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail_FileName",
                schema: "ChatMesssage",
                table: "Categories",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail_FilePath",
                schema: "ChatMesssage",
                table: "Categories",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Thumbnail_Size",
                schema: "ChatMesssage",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductAttachments",
                schema: "ChatMesssage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttachments", x => new { x.ProductId, x.Id });
                    table.ForeignKey(
                        name: "FK_ProductAttachments_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ChatMesssage",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAttachments",
                schema: "ChatMesssage");

            migrationBuilder.DropColumn(
                name: "Thumbnail_Extension",
                schema: "ChatMesssage",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Thumbnail_FileName",
                schema: "ChatMesssage",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Thumbnail_FilePath",
                schema: "ChatMesssage",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Thumbnail_Size",
                schema: "ChatMesssage",
                table: "Categories");
        }
    }
}
