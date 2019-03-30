using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeBase.Infrastracture.Migrations
{
    public partial class removenav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Navigation_NavigationId",
                table: "Document");

            migrationBuilder.DropTable(
                name: "Navigation");

            migrationBuilder.DropIndex(
                name: "IX_Document_NavigationId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "NavigationId",
                table: "Document");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NavigationId",
                table: "Document",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Navigation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DocTypeId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Navigation_DocType_DocTypeId",
                        column: x => x.DocTypeId,
                        principalTable: "DocType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_NavigationId",
                table: "Document",
                column: "NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Navigation_DocTypeId",
                table: "Navigation",
                column: "DocTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Navigation_NavigationId",
                table: "Document",
                column: "NavigationId",
                principalTable: "Navigation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
