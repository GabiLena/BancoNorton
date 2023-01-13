using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoNorton.DAL.Migrations
{
    public partial class Configura_Conta_Fisica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.CreateTable(
                name: "ContasFisicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasFisicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasFisicas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContasJuridicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasJuridicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasJuridicas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContasJuridicas",
                columns: new[] { "Id", "ClienteId", "DataCriacao", "NumeroConta", "Saldo" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), "001", 2147483647 });

            migrationBuilder.CreateIndex(
                name: "IX_ContasFisicas_ClienteId",
                table: "ContasFisicas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContasJuridicas_ClienteId",
                table: "ContasJuridicas",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasFisicas");

            migrationBuilder.DropTable(
                name: "ContasJuridicas");

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NumeroConta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "ClienteId", "DataCriacao", "NumeroConta", "Saldo" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), "001", 2147483647 });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_ClienteId",
                table: "Contas",
                column: "ClienteId");
        }
    }
}
