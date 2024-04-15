using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_teamTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeamID = table.Column<int>(type: "int", nullable: true),
                    GuestTeamID = table.Column<int>(type: "int", nullable: true),
                    MatchDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stadium = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_Match_Teams_GuestTeamID",
                        column: x => x.GuestTeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                    table.ForeignKey(
                        name: "FK_Match_Teams_HomeTeamID",
                        column: x => x.HomeTeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_GuestTeamID",
                table: "Match",
                column: "GuestTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamID",
                table: "Match",
                column: "HomeTeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
