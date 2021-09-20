using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxaEx01
{
    public class Produto 
    {


        //public List<Produto> Directors = new List<Produto>();
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double ValorUnitario { get; set; }


        public Produto(int codigo, string descricao, double valorUnitario)
        {
            Codigo = codigo;
            Descricao = descricao;
            ValorUnitario = valorUnitario;
        }

    }
   
}
