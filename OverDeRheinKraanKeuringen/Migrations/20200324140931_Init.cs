using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OverDeRheinKraanKeuringen.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkInstruction = table.Column<string>(maxLength: 500, nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    CableSupplier = table.Column<string>(maxLength: 250, nullable: true),
                    Observations = table.Column<string>(maxLength: 500, nullable: true),
                    Signature = table.Column<byte[]>(nullable: true),
                    OperatingHours = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cableCheckLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Breakage_6D = table.Column<int>(nullable: false),
                    Breakage_30D = table.Column<int>(nullable: false),
                    DamageOutside = table.Column<int>(nullable: false),
                    DamageCorrosion = table.Column<int>(nullable: false),
                    ReducedCableDiameter = table.Column<int>(nullable: false),
                    PositionMeasuringPoints = table.Column<int>(nullable: false),
                    DamageTotal = table.Column<int>(nullable: false),
                    AssignmentModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cableCheckLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cableCheckLists_Assignments_AssignmentModelId",
                        column: x => x.AssignmentModelId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "damageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    CableChecklistModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_damageTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_damageTypes_cableCheckLists_CableChecklistModelId",
                        column: x => x.CableChecklistModelId,
                        principalTable: "cableCheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cableCheckLists_AssignmentModelId",
                table: "cableCheckLists",
                column: "AssignmentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_damageTypes_CableChecklistModelId",
                table: "damageTypes",
                column: "CableChecklistModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "damageTypes");

            migrationBuilder.DropTable(
                name: "cableCheckLists");

            migrationBuilder.DropTable(
                name: "Assignments");
        }
    }
}
