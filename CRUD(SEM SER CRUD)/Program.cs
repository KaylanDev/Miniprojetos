using CRUD_SEM_SER_CRUD_;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;







//iniciando a adição ao estoque
while (true) {
    string R;

    Console.WriteLine("deseja Adicionar(1) remover (2)  modificar(3)  ou ver os Produtos(4)?");
    int opc = int.Parse(Console.ReadLine());
    switch (opc) {
        case 1:
            Console.WriteLine("qual vc deseja adicionar?(sair(1) continuar (PRESS ENTER))");
             R = Console.ReadLine();
            if (R == "1") {
                break;
            }
            Dados.Adiocionar();
            break;
        case 2:
            Console.WriteLine("qual vc deseja remover?(sair(1) continuar (PRESS ENTER))");
            R = Console.ReadLine();
            if (R == "1") {
                break;
            }
            Dados.Deletar();
            break;
        case 3:
            Console.WriteLine("qual vc deseja mudar?(sair(1) continuar (PRESS ENTER))");

            R = Console.ReadLine();
            if ( R == "1") {
              break;
            }
            Dados.Modificar();

            break;
        case 4:
            Dados.GetProdutos();
            break;

    }




}
