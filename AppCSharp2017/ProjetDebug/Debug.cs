using FilmsDAL;
using SmartVideoDAL;
using SmartVideoDTOLibrary;
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
            //FilmsDALManager db = new FilmsDALManager(@"(localdb)\ProjectsV13"); // Toine
            FilmsDALManager db = new FilmsDALManager(@"(localdb)\MSSQLLocalDB");    // Rémy
            List<Genre> liststr = db.getGenre(5);
            List<Actor> listact = db.getActor(5);
            List<Realisateur> listreal = db.getProducer(5);
            if (liststr.Count == 0)
                Console.WriteLine("Pas de genre");
            else
            {
                foreach (Genre str in liststr)
                {
                    Console.WriteLine(str.name);
                }
            }
            if(listact.Count == 0)
                Console.WriteLine("Pas d'acteurs");
            else
            {
                foreach (Actor str in listact)
                {
                    Console.WriteLine(str.name);
                }
            }
            if (listreal.Count == 0)
                Console.WriteLine("Pas de realisateur");
            else
            {
                foreach (Realisateur str in listreal)
                {
                    Console.WriteLine(str.name);
                }
            }







      




            Console.WriteLine("\n+++Test de Hit+++");
            //SmartVideoDALManager dbSV = new SmartVideoDALManager(@"(localdb)\ProjectsV13");
            SmartVideoDALManager dbSV = new SmartVideoDALManager(@"(localdb)\MSSQLLocalDB");
            HitDTO newh = new HitDTO(11, TypeEnum.Film, DateTime.Now, 6);
            dbSV.addHit(newh);
            List<HitDTO> listHit = dbSV.getHit();
            if (listHit == null)
                Console.WriteLine("Pas de hit");
            else
            {
                foreach (HitDTO str in listHit)
                {
                    Console.WriteLine(str.ToString());
                }
            }
            Console.ReadKey();    
        }
    }
}
