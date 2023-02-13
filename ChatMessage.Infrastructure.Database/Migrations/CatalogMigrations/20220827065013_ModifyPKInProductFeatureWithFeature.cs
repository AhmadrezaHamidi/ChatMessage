using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatMesssage.Infrastructure.Database.Migrations.ChatMesssageMigrations
{
    public partial class ModifyPKInProductFeatureWithFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFeatureValues",
                schema: "ChatMesssage",
                table: "ProductFeatureValues");

            migrationBuilder.DropIndex(
                name: "IX_ProductFeatureValues_ProductId",
                schema: "ChatMesssage",
                table: "ProductFeatureValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFeatureValues",
                schema: "ChatMesssage",
                table: "ProductFeatureValues",
                columns: new[] { "ProductId", "FeatureId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFeatureValues",
                schema: "ChatMesssage",
                table: "ProductFeatureValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFeatureValues",
                schema: "ChatMesssage",
                table: "ProductFeatureValues",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatureValues_ProductId",
                schema: "ChatMesssage",
                table: "ProductFeatureValues",
                column: "ProductId");
        }
    }
}
