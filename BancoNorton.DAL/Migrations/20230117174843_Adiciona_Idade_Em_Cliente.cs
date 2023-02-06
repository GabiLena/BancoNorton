using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoNorton.DAL.Migrations
{
    public partial class Adiciona_Idade_Em_Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "ContasFisicas",
                columns: new[] { "Id", "ClienteId", "DataCriacao", "NumeroConta", "Saldo" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), "002", 2147483647 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContasFisicas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Clientes");
        }
    }
}
