using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AndersenCoreApp.Migrations
{
    public partial class ConfigureRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelationCategory",
                columns: table => new
                {
                    RelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRelationCategory", x => new { x.CategoryId, x.RelationId });
                    table.ForeignKey("FK_tblRelation", x => x.RelationId, "tblRelation", "Id");
                    table.ForeignKey("FK_tblCategory", x => x.CategoryId, "tblCategory", "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblRelationCategory");
        }
    }
}
