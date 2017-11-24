using FilmsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDebug
{
    class Debug
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Outil de test ===");
            Console.WriteLine("+++Test de getGenre+++");
            FilmsDALManager db = new FilmsDALManager("(localdb)\\MSSQLLocalDB");
            List<Genre> strlist = db.getGenre(11);
            if (strlist == null)
                Console.WriteLine("Pas de genre");
            else
            {
                foreach (Genre str in strlist)
                {
                    Console.WriteLine(str.id+" = "+str.name);
                }
            }
            Console.ReadKey();    
        }
    }
}
