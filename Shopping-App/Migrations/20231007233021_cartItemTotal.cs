using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopping_App.Migrations
{
    /// <inheritdoc />
    public partial class cartItemTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ItemTotal",
                table: "CartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemTotal",
                table: "CartItems");
        }
    }
}
