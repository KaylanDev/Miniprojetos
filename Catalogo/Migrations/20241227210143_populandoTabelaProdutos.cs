using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo.Migrations
{
    /// <inheritdoc />
    public partial class populandoTabelaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into produtos(nome,descricao,preco,imagemurl,estoque,datacadastro,categoriaid)" +
                " Values('Coca-Cola Diet','Refrigerante de Cocal-Cola 350ML',5.45,'cocacola.jpg',50,now(),1)");

            mb.Sql("Insert into produtos(nome,descricao,preco,imagemurl,estoque,datacadastro,categoriaid) " +
                "Values('Lanche de Atum','Lanche de Atum com Maionese',8.50,'lancheatum.jpg',10,now(),2)");

            mb.Sql("Insert into produtos(nome,descricao,preco,imagemurl,estoque,datacadastro,categoriaid)" +
                " Values('Pudim 100g','Pudim de Leite condensado 100g',6.75,'pudim.jpg',20,now(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from produtos");
        }
    }
}
