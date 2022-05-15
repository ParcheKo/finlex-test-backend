using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Infrastructure.Migrations
{
    public partial class MakeEmailValueNonNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_persons_email",
                schema: "orders",
                table: "persons");

            migrationBuilder.CreateIndex(
                name: "ix_persons_email",
                schema: "orders",
                table: "persons",
                column: "email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_persons_email",
                schema: "orders",
                table: "persons");

            migrationBuilder.CreateIndex(
                name: "ix_persons_email",
                schema: "orders",
                table: "persons",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }
    }
}
