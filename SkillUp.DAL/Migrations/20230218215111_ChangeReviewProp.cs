using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeReviewProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseReviews_AspNetUsers_AppUserId",
                table: "CourseReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_AspNetUsers_AppUserId",
                table: "ProductReviews");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "ProductReviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "CourseReviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseReviews_AspNetUsers_AppUserId",
                table: "CourseReviews",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_AspNetUsers_AppUserId",
                table: "ProductReviews",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseReviews_AspNetUsers_AppUserId",
                table: "CourseReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_AspNetUsers_AppUserId",
                table: "ProductReviews");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "ProductReviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "CourseReviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseReviews_AspNetUsers_AppUserId",
                table: "CourseReviews",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_AspNetUsers_AppUserId",
                table: "ProductReviews",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
