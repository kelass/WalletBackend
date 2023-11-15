using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteDraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Draft",
                table: "Bills");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Draft",
                table: "Bills",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
