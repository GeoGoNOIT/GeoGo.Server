#nullable disable

namespace GeoGo.Server.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UserProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clue_Riddle_RiddleId",
                table: "Clue");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_AspNetUsers_UserId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Games_GameId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Category_CategoryId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Address_AddressId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Games_RiddleId",
                table: "Stage");

            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Location_RiddleId",
                table: "Stage");

            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Riddle_RiddleId",
                table: "Stage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stage",
                table: "Stage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Riddle",
                table: "Riddle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clue",
                table: "Clue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Stage",
                newName: "Stages");

            migrationBuilder.RenameTable(
                name: "Riddle",
                newName: "Riddles");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "Clue",
                newName: "Clues");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "ProfilePhotoUrl",
                table: "AspNetUsers",
                newName: "Profile_ProfilePhotoUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Stage_RiddleId",
                table: "Stages",
                newName: "IX_Stages_RiddleId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_AddressId",
                table: "Locations",
                newName: "IX_Locations_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_UserId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_GameId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Clue_RiddleId",
                table: "Clues",
                newName: "IX_Clues_RiddleId");

            migrationBuilder.AddColumn<string>(
                name: "Profile_Bio",
                table: "AspNetUsers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Profile_Location",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stages",
                table: "Stages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Riddles",
                table: "Riddles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clues",
                table: "Clues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clues_Riddles_RiddleId",
                table: "Clues",
                column: "RiddleId",
                principalTable: "Riddles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_UserId",
                table: "Feedbacks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Games_GameId",
                table: "Feedbacks",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Addresses_AddressId",
                table: "Locations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Games_RiddleId",
                table: "Stages",
                column: "RiddleId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Locations_RiddleId",
                table: "Stages",
                column: "RiddleId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Riddles_RiddleId",
                table: "Stages",
                column: "RiddleId",
                principalTable: "Riddles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clues_Riddles_RiddleId",
                table: "Clues");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_UserId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Games_GameId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Addresses_AddressId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Games_RiddleId",
                table: "Stages");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Locations_RiddleId",
                table: "Stages");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Riddles_RiddleId",
                table: "Stages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stages",
                table: "Stages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Riddles",
                table: "Riddles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clues",
                table: "Clues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Profile_Bio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_Location",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Stages",
                newName: "Stage");

            migrationBuilder.RenameTable(
                name: "Riddles",
                newName: "Riddle");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "Feedback");

            migrationBuilder.RenameTable(
                name: "Clues",
                newName: "Clue");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Profile_ProfilePhotoUrl",
                table: "AspNetUsers",
                newName: "ProfilePhotoUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Stages_RiddleId",
                table: "Stage",
                newName: "IX_Stage_RiddleId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_AddressId",
                table: "Location",
                newName: "IX_Location_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedback",
                newName: "IX_Feedback_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_GameId",
                table: "Feedback",
                newName: "IX_Feedback_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Clues_RiddleId",
                table: "Clue",
                newName: "IX_Clue_RiddleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stage",
                table: "Stage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Riddle",
                table: "Riddle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clue",
                table: "Clue",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clue_Riddle_RiddleId",
                table: "Clue",
                column: "RiddleId",
                principalTable: "Riddle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_AspNetUsers_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Games_GameId",
                table: "Feedback",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Category_CategoryId",
                table: "Games",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Address_AddressId",
                table: "Location",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Games_RiddleId",
                table: "Stage",
                column: "RiddleId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Location_RiddleId",
                table: "Stage",
                column: "RiddleId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Riddle_RiddleId",
                table: "Stage",
                column: "RiddleId",
                principalTable: "Riddle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
