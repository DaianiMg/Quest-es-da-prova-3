using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova02
{
   
    class IdsRoot 
    {
        
         public IEnumerable<int> Ids { get; set; }

        public async void PopularIds()
        {
            DataService dataService = new DataService();

            Ids = await dataService.ObterIdsFiltradosAsync();

        }

    }
}
