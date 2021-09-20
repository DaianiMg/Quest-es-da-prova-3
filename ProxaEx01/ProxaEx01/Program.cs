using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ProxaEx01
{
    class Program
    {
        static void Main(string[] args)
        {

            bool exibeMenu = true;
            while (exibeMenu)
            {
                exibeMenu = Menu();
            }

        }
        private static bool Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ PEDIDOS ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");
            Console.WriteLine("║ 1 EFETUAR PEDIDO                              ║    ");
            Console.WriteLine("║ 2 SAIR                                        ║    ");
            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");

            Console.WriteLine(" ");
            Console.Write("DIGITE UMA OPÇÃO : ");

            switch (Console.ReadLine())
            {
                case "1":
                    Pedidos();
                    return true;
                case "2":
                    return false;
                default:
                    return true;
            }
        }
        private static void Pedidos() // Verefica se a mesa está disponível
        {
            Console.Clear();

            Pedido pedido = new Pedido();

            int[] mesasArray = { 1, 2, 3, 4 };

            while (true)
            {
                Console.Write("Qual o numero da mesa? ");
                int mesas = int.Parse(Console.ReadLine());

                if(mesasArray.Any(m => m == mesas))
                {
                    EfetuandoPedido(); 
                    break;
                }
                else 
                {
                    Console.WriteLine("Numero inválido");

                    Thread.Sleep(1000);

                    Console.Clear();
                }
            }

            // TODO
            Console.Write("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }

        private static void EfetuandoPedido() //Aqui vai ser feito o pedido
        {
            
            Pedido pedido = new Pedido();
            Cardapio cardapio = new Cardapio();
            

            Console.WriteLine("Qual  o item (Codigo) do pedido abaixo? ");
            Console.WriteLine();

            int codigoProduto ;


            while (true)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();

                Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒  CARDÁPIO  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.WriteLine(" ");
                Console.WriteLine();
                Console.Write("Código \t ║ \t Produto \t ║ \t Preço Unitário (R$) \n");
                Console.WriteLine(); 
                pedido.ListaDeProduto();
                Console.Write("Informe o Código: ");

                codigoProduto = int.Parse(Console.ReadLine());

                int quantProduto;

                Produto produtoAtual = null;
                if( cardapio.TotalLista().Any(l => l.Codigo == codigoProduto))
                {
                    foreach (Produto p in cardapio.TotalLista())
                    {
                        if (p.Codigo == codigoProduto)
                        {
                            produtoAtual = p;
                        }
                    }
                    Console.Write("Informe a quantidade: ");
                    quantProduto = int.Parse(Console.ReadLine());

                    pedido.ValorTotalCliente(produtoAtual, quantProduto);
                    
                }
                else if (codigoProduto == 999)
                {
                    FinalizarPedido(pedido);
                    break;
                }
                else
                {
                    Console.WriteLine("Código do pedido inválido");

                    Thread.Sleep(1000);
                }
                
            }

        }

        private static void FinalizarPedido(Pedido pedido) //usei só para teste, se está avançando certinho
        {

            pedido.MostrarPedido();
            Console.WriteLine();
            var json = JsonConvert.SerializeObject(pedido, Formatting.Indented);
            Console.WriteLine(json);
        }
        
    }

}
