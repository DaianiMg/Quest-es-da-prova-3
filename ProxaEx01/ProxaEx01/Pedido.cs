using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxaEx01
{
    public class Pedido 
    {
        public double ValorTotal;
        public List<Produto> itens = new List<Produto>();
        public void ListaDeProduto()
        { 
            int valorPagar;

            Cardapio cardapio = new Cardapio();

            foreach (var Produto in cardapio.TotalLista())
            {
                Console.WriteLine($"{Produto.Codigo} \t ║ \t {Produto.Descricao}\t ║ \t {Produto.ValorUnitario:c}");
                //Thread.Sleep(500);
            }
            Console.WriteLine("\n999\t\tEncerrar pedido\n");

        }

        public void ValorTotalCliente(Produto produto, int quantidade)
        {

            ValorTotal += (produto.ValorUnitario * quantidade);

            itens.Add(produto);

        }
        public void MostrarPedido()
        {
            string final = string.Empty;
            int index = 1;

            foreach (var produto in itens)
            {
                final += $"{index } - {produto.Descricao} \n";
                index++;
            }

            final += $"Com valor Total de {ValorTotal:c}";
            Console.WriteLine(final);
        }
     
    }
}
