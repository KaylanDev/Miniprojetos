using CRUD_SEM_SER_CRUD_.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_SEM_SER_CRUD_ {
    internal class Dados {
        [Key]
        public int Id { get;private set; }
        public string Nome { get; private set; }
        public double Preco { get; private set; }
        public int CC { get; private set; }
        private static AplicationDbContext _db = new AplicationDbContext();



    
        public Dados() {

        }


        //funcao para adicionar
       public static void Adiocionar()
        {
            Console.WriteLine("insira as informações da moto:");

            Console.Write("NOME:");
            string nome = Console.ReadLine();

            Console.Write("PREÇO:");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("CC(CILINDRADA):");
            int cc = int.Parse(Console.ReadLine());


            using (var db = new AplicationDbContext())
            {

                var Cliente = new Dados { Nome = nome, Preco = preco, CC = cc };
                db.Motos.Add(Cliente);
                db.SaveChanges();
            }

        }

        //funcao para modificar
        public static void Modificar()
        {
            GetProdutos();
            Console.Write("Escolha o Produto Desejado pelo Id:");
            var moto = _db.Motos.Find(int.Parse(Console.ReadLine()));

            Console.WriteLine("Oque deseja alterar? NOME(1), PREÇO(2), CC(3)");
            int Moto = int.Parse(Console.ReadLine());
            switch (Moto)
            {
                case 1:
                    string nome;
                    string opc;
                    while (true)
                    {
                        Console.Write("Escolha o nome que deseja colocar:");
                         nome = Console.ReadLine();
                        Console.WriteLine("Tem certeza?S/N");
                         opc = Console.ReadLine();
                        if (opc == "S" || opc == "s")
                        {
                            break;

                        }
                    }
                    moto.Nome = nome;


                    _db.SaveChanges();


                    break;
                case 2:
                    double preco;
                    while (true)
                    {
                        Console.Write("Escolha o preço que deseja colocar:");
                         preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.WriteLine("Tem certeza?S/N");
                        opc = Console.ReadLine();
                        if (opc == "S" || opc == "s")
                        {
                            break;

                        }
                    }
                    moto.Preco = preco;


                    _db.SaveChanges();
                    break;
                case 3:
                    int Cc;

                    while (true)
                    {
                        Console.Write("Escolha a CC que deseja colocar:");
                        Cc = int.Parse(Console.ReadLine());
                        Console.WriteLine("Tem certeza?S/N");
                        opc = Console.ReadLine();
                        if (opc == "S" || opc == "s")
                        {
                            break;

                        }
                    }

                    moto.CC = Cc;


                    _db.SaveChanges();
                    break;
            }
        }

        //funcao para deletar
        public static void Deletar()
        {
            Console.WriteLine("qual vc deseja remover?");
            GetProdutos();
            while (true)
            {
                int i = int.Parse(Console.ReadLine());
                var moto = _db.Motos.Find(i);
                if (moto != null)
                {

                    Console.WriteLine($"Tem certeza que deseja remover o produto {moto.Nome}?S/N");
                    string opc = Console.ReadLine();
                    if (opc == "S" || opc == "s")
                    {
                        _db.Remove(moto);
                        _db.SaveChanges();
                        break;

                    };



                }
            }

            
        }

        //funcao para mostrar os produtos
        public static void GetProdutos()
        {

            IEnumerable<Dados> Motos = _db.Motos;
                foreach (var item in Motos)
                {
                    
                    Console.WriteLine($"{item.Id}-" + item.ToString());
                }
            
        }



        public override string ToString() {
                
            return $"Nome:{Nome}, Preço:{Preco.ToString("f3",CultureInfo.InvariantCulture)} , CC(Cilindrada):{CC}";
        }

    }
}
