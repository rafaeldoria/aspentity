using Microsoft.EntityFrameworkCore.Migrations;

namespace aspentity.Migrations
{
    public partial class updateTableProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "ProdutosLoja");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoriaId",
                table: "ProdutosLoja",
                newName: "IX_ProdutosLoja_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ProdutosLoja",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutosLoja",
                table: "ProdutosLoja",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosLoja_Categorias_CategoriaId",
                table: "ProdutosLoja",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosLoja_Categorias_CategoriaId",
                table: "ProdutosLoja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutosLoja",
                table: "ProdutosLoja");

            migrationBuilder.RenameTable(
                name: "ProdutosLoja",
                newName: "Produtos");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutosLoja_CategoriaId",
                table: "Produtos",
                newName: "IX_Produtos_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
