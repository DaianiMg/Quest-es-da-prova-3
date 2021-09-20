using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova02 
{ 
    class DataService : IDataService
    {
        
        public async Task<IEnumerable<Atributos>> ObterAtributosDeClasseAsync()
        {
            string json = await File.ReadAllTextAsync("atributos.json");
            var data = JsonConvert.DeserializeObject<AtributosRoot>(json);
            return data.Atributos;
        }

        public async Task<IEnumerable<Classe>> ObterClassesAsync()
        {
            string json = await File.ReadAllTextAsync("classes.json");
            var data = JsonConvert.DeserializeObject<ClassesRoot>(json);
            return data.Classe;
        }

        public async Task<IEnumerable<int>> ObterIdsFiltradosAsync()
        {
            string json = await File.ReadAllTextAsync("ids_filtrados.json");
            var data = JsonConvert.DeserializeObject<IdsRoot>(json);
            return data.Ids;
        }
    }
}
