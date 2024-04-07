using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRMExam.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_MarketingId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_MarketingId",
                table: "Contacts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MarketingId",
                table: "Contacts",
                column: "MarketingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_MarketingId",
                table: "Contacts",
                column: "MarketingId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
