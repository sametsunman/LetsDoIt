using Microsoft.EntityFrameworkCore.Migrations;

namespace LDI.DataAccess.Migrations
{
    public partial class version_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChannelID",
                table: "Contents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChannelID",
                table: "Contents");
        }
    }
}
