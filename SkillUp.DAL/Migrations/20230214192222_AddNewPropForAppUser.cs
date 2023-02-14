using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropForAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStudent",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStudent",
                table: "AspNetUsers");
        }
    }
}
