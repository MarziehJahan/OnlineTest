using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.DAL.Migrations
{
    public partial class AddRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickedByUser",
                table: "answerDetails");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "choices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ChoiceId",
                table: "answerDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PickedByUserUserId",
                table: "answerDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_choices_QuestionId",
                table: "choices",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_answerDetails_ChoiceId",
                table: "answerDetails",
                column: "ChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_answerDetails_PickedByUserUserId",
                table: "answerDetails",
                column: "PickedByUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_answerDetails_choices_ChoiceId",
                table: "answerDetails",
                column: "ChoiceId",
                principalTable: "choices",
                principalColumn: "ChoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_answerDetails_Users_PickedByUserUserId",
                table: "answerDetails",
                column: "PickedByUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_choices_Questions_QuestionId",
                table: "choices",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answerDetails_choices_ChoiceId",
                table: "answerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_answerDetails_Users_PickedByUserUserId",
                table: "answerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_choices_Questions_QuestionId",
                table: "choices");

            migrationBuilder.DropIndex(
                name: "IX_choices_QuestionId",
                table: "choices");

            migrationBuilder.DropIndex(
                name: "IX_answerDetails_ChoiceId",
                table: "answerDetails");

            migrationBuilder.DropIndex(
                name: "IX_answerDetails_PickedByUserUserId",
                table: "answerDetails");

            migrationBuilder.DropColumn(
                name: "PickedByUserUserId",
                table: "answerDetails");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "choices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChoiceId",
                table: "answerDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PickedByUser",
                table: "answerDetails",
                nullable: false,
                defaultValue: 0);
        }
    }
}
