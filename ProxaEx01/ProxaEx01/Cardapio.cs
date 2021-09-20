using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxaEx01
{
    public class Cardapio
    {


        private static List<Produto> listaProdutos = new List<Produto>()
        {

            new Produto ( 100, "Cachorro quente ", 5.70 ),
            new Produto ( 101, "X Completo", 18.30 ),
            new Produto ( 102, "X Salada", 16.50),
            new Produto ( 103, "Hamburguer", 22.40 ),
            new Produto ( 104, "Coca 2L", 10.00 ),
            new Produto ( 105, "Refrigerante", 1.00 )

        };
        public List<Produto> TotalLista()
        {
            return listaProdutos;
        }
        
    }
}
