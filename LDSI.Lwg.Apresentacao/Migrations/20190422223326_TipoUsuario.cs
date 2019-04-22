using Microsoft.EntityFrameworkCore.Migrations;

namespace LDSI.Lwg.Apresentacao.Migrations
{
    public partial class TipoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<short>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<short>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
