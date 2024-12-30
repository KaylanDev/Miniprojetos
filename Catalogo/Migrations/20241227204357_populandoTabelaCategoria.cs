using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo.Migrations
{
    /// <inheritdoc />
    public partial class populandoTabelaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categoria(Nome,ImagemUrl) Values('Bebidas','Bebidas.jpg')");
            mb.Sql("Insert into Categoria(Nome,ImagemUrl) Values('Lanches','Lanches.jpg')");
            mb.Sql("Insert into Categoria(Nome,ImagemUrl) Values('Sobremesas','Sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete  From Categoria");
        }
    }
}
