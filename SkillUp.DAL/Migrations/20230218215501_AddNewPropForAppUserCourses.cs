using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropForAppUserCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBuyed",
                table: "AppUserCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBuyed",
                table: "AppUserCourses");
        }
    }
}
