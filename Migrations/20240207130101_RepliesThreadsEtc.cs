using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymousForum.Migrations
{
    /// <inheritdoc />
    public partial class RepliesThreadsEtc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Replies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Replies");
        }
    }
}
