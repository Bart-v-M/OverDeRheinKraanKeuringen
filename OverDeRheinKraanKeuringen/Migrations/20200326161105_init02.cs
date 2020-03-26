using Microsoft.EntityFrameworkCore.Migrations;

namespace OverDeRheinKraanKeuringen.Migrations
{
    public partial class init02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cableCheckLists_Assignments_AssignmentModelId",
                table: "cableCheckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_damageTypes_cableCheckLists_CableChecklistModelId",
                table: "damageTypes");

            migrationBuilder.DropIndex(
                name: "IX_damageTypes_CableChecklistModelId",
                table: "damageTypes");

            migrationBuilder.DropIndex(
                name: "IX_cableCheckLists_AssignmentModelId",
                table: "cableCheckLists");

            migrationBuilder.DropColumn(
                name: "CableChecklistModelId",
                table: "damageTypes");

            migrationBuilder.DropColumn(
                name: "AssignmentModelId",
                table: "cableCheckLists");

            migrationBuilder.AddColumn<int>(
                name: "CableChecklistId",
                table: "damageTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "cableCheckLists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_damageTypes_CableChecklistId",
                table: "damageTypes",
                column: "CableChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_cableCheckLists_AssignmentId",
                table: "cableCheckLists",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_cableCheckLists_Assignments_AssignmentId",
                table: "cableCheckLists",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_damageTypes_cableCheckLists_CableChecklistId",
                table: "damageTypes",
                column: "CableChecklistId",
                principalTable: "cableCheckLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cableCheckLists_Assignments_AssignmentId",
                table: "cableCheckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_damageTypes_cableCheckLists_CableChecklistId",
                table: "damageTypes");

            migrationBuilder.DropIndex(
                name: "IX_damageTypes_CableChecklistId",
                table: "damageTypes");

            migrationBuilder.DropIndex(
                name: "IX_cableCheckLists_AssignmentId",
                table: "cableCheckLists");

            migrationBuilder.DropColumn(
                name: "CableChecklistId",
                table: "damageTypes");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "cableCheckLists");

            migrationBuilder.AddColumn<int>(
                name: "CableChecklistModelId",
                table: "damageTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentModelId",
                table: "cableCheckLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_damageTypes_CableChecklistModelId",
                table: "damageTypes",
                column: "CableChecklistModelId");

            migrationBuilder.CreateIndex(
                name: "IX_cableCheckLists_AssignmentModelId",
                table: "cableCheckLists",
                column: "AssignmentModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_cableCheckLists_Assignments_AssignmentModelId",
                table: "cableCheckLists",
                column: "AssignmentModelId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_damageTypes_cableCheckLists_CableChecklistModelId",
                table: "damageTypes",
                column: "CableChecklistModelId",
                principalTable: "cableCheckLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
