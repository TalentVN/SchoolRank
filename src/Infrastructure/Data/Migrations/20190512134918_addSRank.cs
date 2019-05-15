using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class addSRank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    Localtion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SRanks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializeds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SchoolProfileId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializeds_SchoolProfiles_SchoolProfileId",
                        column: x => x.SchoolProfileId,
                        principalTable: "SchoolProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SRankItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    SchoolProfileId = table.Column<string>(nullable: true),
                    SRankId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRankItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SRankItems_SRanks_SRankId",
                        column: x => x.SRankId,
                        principalTable: "SRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SRankItems_SchoolProfiles_SchoolProfileId",
                        column: x => x.SchoolProfileId,
                        principalTable: "SchoolProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specializeds_SchoolProfileId",
                table: "Specializeds",
                column: "SchoolProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SRankItems_SRankId",
                table: "SRankItems",
                column: "SRankId");

            migrationBuilder.CreateIndex(
                name: "IX_SRankItems_SchoolProfileId",
                table: "SRankItems",
                column: "SchoolProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specializeds");

            migrationBuilder.DropTable(
                name: "SRankItems");

            migrationBuilder.DropTable(
                name: "SRanks");

            migrationBuilder.DropTable(
                name: "SchoolProfiles");
        }
    }
}
