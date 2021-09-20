using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova02
{
    interface IDataService
    {
        Task<IEnumerable<Classe>> ObterClassesAsync();
        Task<IEnumerable<int>> ObterIdsFiltradosAsync();
        Task<IEnumerable<Atributos>> ObterAtributosDeClasseAsync();
    }
}
