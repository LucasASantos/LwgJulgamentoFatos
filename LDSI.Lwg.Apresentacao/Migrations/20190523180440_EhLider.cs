using Microsoft.EntityFrameworkCore.Migrations;

namespace LDSI.Lwg.Apresentacao.Migrations
{
    public partial class EhLider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EhLider",
                table: "Integrante",
                nullable: false,
                oldClrType: typeof(short));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "EhLider",
                table: "Integrante",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
