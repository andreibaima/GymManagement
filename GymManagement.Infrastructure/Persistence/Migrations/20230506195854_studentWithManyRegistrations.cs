using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagement.Infrastructure.Persistence.Migrations
{
    public partial class studentWithManyRegistrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registrations_StudentCode",
                table: "Registrations");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_StudentCode",
                table: "Registrations",
                column: "StudentCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registrations_StudentCode",
                table: "Registrations");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_StudentCode",
                table: "Registrations",
                column: "StudentCode",
                unique: true);
        }
    }
}
