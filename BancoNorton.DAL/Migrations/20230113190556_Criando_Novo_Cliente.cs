using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoNorton.DAL.Migrations
{
    public partial class Criando_Novo_Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cpf", "Nome" },
                values: new object[] { 2, "456.890.158-81", "Gabriela Lena" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
