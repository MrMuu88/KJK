using Microsoft.EntityFrameworkCore.Migrations;

namespace KJK.Data.Migrations
{
    public partial class WorkingOnBaseTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Agility",
                table: "Monsters",
                newName: "Wisdom");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Items",
                newName: "MaxStack");

            migrationBuilder.AddColumn<int>(
                name: "Charisma",
                table: "Monsters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dexterity",
                table: "Monsters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Intelect",
                table: "Monsters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mana",
                table: "Monsters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stamina",
                table: "Monsters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "Monsters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsConsumable",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Slot",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Items",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Charisma",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Dexterity",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Intelect",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Mana",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Stamina",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "IsConsumable",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Slot",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Wisdom",
                table: "Monsters",
                newName: "Agility");

            migrationBuilder.RenameColumn(
                name: "MaxStack",
                table: "Items",
                newName: "Amount");
        }
    }
}
