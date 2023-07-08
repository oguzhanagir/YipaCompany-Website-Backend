using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yipa.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateServiceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubContent",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubContent",
                table: "Services");
        }
    }
}
