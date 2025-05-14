using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsNdv.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPersonIdContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Person_PersonId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owners_ownerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "ownerId",
                table: "Pets",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_ownerId",
                table: "Pets",
                newName: "IX_Pets_OwnerId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Person_PersonId",
                table: "Contacts",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Person_PersonId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Pets",
                newName: "ownerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_OwnerId",
                table: "Pets",
                newName: "IX_Pets_ownerId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Person_PersonId",
                table: "Contacts",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owners_ownerId",
                table: "Pets",
                column: "ownerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
