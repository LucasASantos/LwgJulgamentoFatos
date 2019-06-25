using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LDSI.Lwg.Apresentacao.Migrations
{
    public partial class JulgamentoFatosEquipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "JulgamentoFatosId",
                table: "Equipe",
                nullable: false
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JulgamentoFatosId",
                table: "Equipe");
        }
    }
}
