using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInstructors");

            migrationBuilder.AddColumn<string>(
                name: "InstructorId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InstructorId",
                table: "Products",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Instructors_InstructorId",
                table: "Products",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Instructors_InstructorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_InstructorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductInstructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInstructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInstructors_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInstructors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInstructors_InstructorId",
                table: "ProductInstructors",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInstructors_ProductId",
                table: "ProductInstructors",
                column: "ProductId");
        }
    }
}
