using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Database.Migrations
{
    /// <inheritdoc />
    public partial class OptionalRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_project_user_owner_id",
                table: "project");

            migrationBuilder.AlterColumn<int>(
                name: "owner_id",
                table: "project",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_project_user_owner_id",
                table: "project",
                column: "owner_id",
                principalTable: "user",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_project_user_owner_id",
                table: "project");

            migrationBuilder.AlterColumn<int>(
                name: "owner_id",
                table: "project",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_project_user_owner_id",
                table: "project",
                column: "owner_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
