using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppUserClubs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Clubs_GuestId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Clubs_HomeId",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "GuestGoals",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeGoals",
                table: "Matches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppUserClubs",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClubs", x => new { x.UserId, x.ClubId });
                    table.ForeignKey(
                        name: "FK_AppUserClubs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserClubs_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClubs_ClubId",
                table: "AppUserClubs",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_ClubStatistics_GuestId",
                table: "Matches",
                column: "GuestId",
                principalTable: "ClubStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_ClubStatistics_HomeId",
                table: "Matches",
                column: "HomeId",
                principalTable: "ClubStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_ClubStatistics_GuestId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_ClubStatistics_HomeId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "AppUserClubs");

            migrationBuilder.DropColumn(
                name: "GuestGoals",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeGoals",
                table: "Matches");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Clubs_GuestId",
                table: "Matches",
                column: "GuestId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Clubs_HomeId",
                table: "Matches",
                column: "HomeId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
