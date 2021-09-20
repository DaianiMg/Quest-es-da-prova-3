using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova02
{
    class AtributosRoot
    {
        public IEnumerable<Atributos> Atributos { get; set; }

        public async void PopularAtributos()
        {
            DataService dataService = new DataService();

            Atributos = await dataService.ObterAtributosDeClasseAsync();

        }


    }
    
}
