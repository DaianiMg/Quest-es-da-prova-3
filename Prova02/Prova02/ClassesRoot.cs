using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova02
{
    class ClassesRoot
    {


        public IEnumerable<Classe> Classe { get; set; }

        public async void PopularClasses()
        {
            DataService dataService = new DataService();

            this.Classe = await dataService.ObterClassesAsync();

        }
    }

    
}
