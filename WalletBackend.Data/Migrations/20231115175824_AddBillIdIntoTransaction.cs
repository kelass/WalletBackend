using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBillIdIntoTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BillId",
                table: "AuthorizeTransactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizeTransactions_BillId",
                table: "AuthorizeTransactions",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorizeTransactions_Bills_BillId",
                table: "AuthorizeTransactions",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorizeTransactions_Bills_BillId",
                table: "AuthorizeTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AuthorizeTransactions_BillId",
                table: "AuthorizeTransactions");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "AuthorizeTransactions");
        }
    }
}
