using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianHeritage.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContributions_AspNetUsers_ApprovedByUserId",
                table: "UserContributions");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContributions_AspNetUsers_ApprovedByUserId",
                table: "UserContributions",
                column: "ApprovedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContributions_AspNetUsers_ApprovedByUserId",
                table: "UserContributions");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContributions_AspNetUsers_ApprovedByUserId",
                table: "UserContributions",
                column: "ApprovedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
