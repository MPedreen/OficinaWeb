using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OficinaWeb.Infra.Repositories.Migrations
{
    public partial class AddDataCadastroToCarros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lucro",
                table: "Produtos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Carros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Carros");

            migrationBuilder.AddColumn<float>(
                name: "Lucro",
                table: "Produtos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
