using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropForAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsStudent",
                table: "AspNetUsers",
                newName: "IsInstructor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsInstructor",
                table: "AspNetUsers",
                newName: "IsStudent");
        }
    }
}
