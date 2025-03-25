using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCascadeForOwnerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_project_user_owner_id",
                table: "project");

            migrationBuilder.AddForeignKey(
                name: "FK_project_user_owner_id",
                table: "project",
                column: "owner_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_project_user_owner_id",
                table: "project");

            migrationBuilder.AddForeignKey(
                name: "FK_project_user_owner_id",
                table: "project",
                column: "owner_id",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
