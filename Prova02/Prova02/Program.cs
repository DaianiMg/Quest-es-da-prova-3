using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Prova02
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassesRoot classesRoot = new ClassesRoot();
            IdsRoot idsRoot = new IdsRoot();
            AtributosRoot atributosRoot = new AtributosRoot();

            Task popularClasses = Task.Run(() => classesRoot.PopularClasses());
            
            Task popularAtributos = Task.Run(() => atributosRoot.PopularAtributos());
            
            Task popularIds = Task.Run(() => idsRoot.PopularIds());
            Task.WaitAll(new Task[] { popularClasses, popularAtributos, popularIds });

            List<Classe> classesFiltradas = new List<Classe>();

            foreach (int id in idsRoot.Ids)
            {
                foreach (Classe classe in classesRoot.Classe)
                {
                    if(id == classe.Id)
                    {
                        classesFiltradas.Add(classe);
                    }
                }
            }

            foreach (Atributos atributos in atributosRoot.Atributos)
            {
                foreach (Classe classe in classesFiltradas)
                {
                    if (classe.Id == atributos.ClasseId)
                    {
                        classe.Atributos = atributos;

                    }
                }
            }

            foreach (Classe item in classesFiltradas)
            {
                Console.WriteLine(@$"       ----    ----        ---         ");
                Console.WriteLine(@$"Id: {item.Id}                          ");
                Console.WriteLine(@$"Nome: {item.NomeClasse}                ");
                Console.WriteLine(@$"      Atributos                        ");
                Console.WriteLine(@$"FOR: {item.Atributos.Forca}            ");
                Console.WriteLine(@$"DES: {item.Atributos.Destreza}         ");
                Console.WriteLine(@$"INT: {item.Atributos.Inteligencia}     ");
                Console.WriteLine(@"                                        ");
            }
        }
        
    }
}
