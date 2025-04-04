using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroUsuarios.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Pessoa",
                newName: "Endereço");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Pessoa",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereço",
                table: "Pessoa",
                newName: "Endereco");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Pessoa",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
