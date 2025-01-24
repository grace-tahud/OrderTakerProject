using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderTakerProject.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addImageInSKUModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "SKUImage",
                table: "SKUs",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SKUImage",
                table: "SKUs");
        }
    }
}
