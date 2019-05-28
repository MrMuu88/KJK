using Microsoft.EntityFrameworkCore.Migrations;

namespace KJK.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: true),
                    SpecialEvent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: true),
                    Reference = table.Column<int>(nullable: false),
                    Special = table.Column<bool>(nullable: false),
                    ParagraphID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Choices_Paragraphs_ParagraphID",
                        column: x => x.ParagraphID,
                        principalTable: "Paragraphs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ParagraphID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Paragraphs_ParagraphID",
                        column: x => x.ParagraphID,
                        principalTable: "Paragraphs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Health = table.Column<int>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    ParagraphID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Monsters_Paragraphs_ParagraphID",
                        column: x => x.ParagraphID,
                        principalTable: "Paragraphs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_ParagraphID",
                table: "Choices",
                column: "ParagraphID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ParagraphID",
                table: "Items",
                column: "ParagraphID");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_ParagraphID",
                table: "Monsters",
                column: "ParagraphID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Paragraphs");
        }
    }
}
