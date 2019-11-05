using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Carros.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: true),
                    Dt_Venda = table.Column<DateTime>(nullable: true),
                    Cor = table.Column<string>(nullable: true),
                    Dt_Inc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Revisoes",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_Revisao = table.Column<DateTime>(nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(9,3)", nullable: true),
                    Oficina = table.Column<string>(maxLength: 200, nullable: true),
                    CarrosCodigo = table.Column<int>(nullable: false),
                    Dt_Inc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisoes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Revisoes_Carros_CarrosCodigo",
                        column: x => x.CarrosCodigo,
                        principalTable: "Carros",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revisoes_CarrosCodigo",
                table: "Revisoes",
                column: "CarrosCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revisoes");

            migrationBuilder.DropTable(
                name: "Carros");
        }
    }
}
