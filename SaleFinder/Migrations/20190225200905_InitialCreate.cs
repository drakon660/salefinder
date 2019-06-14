using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleFinder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leaflets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Week = table.Column<int>(nullable: false),
                    DownloadUrl = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    SaleTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaflets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeafletPageModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PageNumber = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    LeafletModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeafletPageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeafletPageModel_Leaflets_LeafletModelId",
                        column: x => x.LeafletModelId,
                        principalTable: "Leaflets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeafletPageModel_LeafletModelId",
                table: "LeafletPageModel",
                column: "LeafletModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeafletPageModel");

            migrationBuilder.DropTable(
                name: "Leaflets");
        }
    }
}
