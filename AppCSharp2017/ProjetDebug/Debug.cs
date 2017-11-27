﻿using FilmsDAL;
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
        public static int VERSION = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("=== Outil de test ===");
            /*Console.WriteLine("+++Test de Film+++");
            FilmsDALManager db;
            if (VERSION == 1)
                 db = new FilmsDALManager(@"(localdb)\ProjectsV13"); // Toine
            else
                db = new FilmsDALManager(@"(localdb)\MSSQLLocalDB");    // Rémy
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
            }*/

            Console.WriteLine("\n+++Test de Hit+++ ");
            SmartVideoDALManager dbSV;
            if (VERSION == 1)
                dbSV = new SmartVideoDALManager(@"(localdb)\ProjectsV13");
            else
                dbSV = new SmartVideoDALManager(@"(localdb)\MSSQLLocalDB");

            // creation des objets de test
            UserDTO newu = new UserDTO("user", "user", "user");
            HitDTO newh = new HitDTO(11, TypeEnum.Film, DateTime.Now, 45);
            LocationDTO newl = new LocationDTO(112, 11, "Star Wars episode IV", DateTime.Now, (DateTime.Now).AddDays(5), "user");
            StatistiqueDTO news = new StatistiqueDTO(11, TypeEnum.Film, DateTime.Now, 1);

            //recupere les objet dans la BD
            List<HitDTO> listHit;
            List<StatistiqueDTO> listStat;
            List<UserDTO> listUser;
            List<LocationDTO> listLoca;

            ConsoleKeyInfo cki = Console.ReadKey();
            while (cki.KeyChar != 'q')
            {
                Console.WriteLine("");
                switch (cki.KeyChar)
                {
                    case '1': //ajout user
                        dbSV.addUser(newu);
                        break;
                    case '2'://ajout stat
                        dbSV.addStatistique(news);
                        break;
                    case '3'://ajout location
                        dbSV.addLocation(newl);
                        break;
                    case '4'://ajout hit
                        dbSV.addHit(newh);
                        break;
                    case '5'://list user
                        listUser = dbSV.getUser();
                        if (listUser.Count == 0)
                            Console.WriteLine("Aucun user présent");
                        foreach (UserDTO o in listUser)
                        {
                            Console.WriteLine(o.ToString());
                        }
                        break;
                    case '6'://list stat
                        listStat = dbSV.getStatistique();
                        if (listStat.Count == 0)
                            Console.WriteLine("Aucun Stat présent");
                        foreach (StatistiqueDTO o in listStat)
                        {
                            Console.WriteLine(o.ToString());
                        }
                        break;
                    case '7'://list location
                        listLoca = dbSV.getLocation();
                        if (listLoca.Count == 0)
                            Console.WriteLine("Aucun Location présent");
                        foreach (LocationDTO o in listLoca)
                        {
                            Console.WriteLine(o.ToString());
                        }
                        break;
                    case '8'://list hit
                        listHit = dbSV.getHit();
                        if (listHit.Count == 0)
                            Console.WriteLine("Aucun hit présent");
                        foreach (HitDTO o in listHit)
                        {
                            Console.WriteLine(o.ToString());
                        }
                        break;
                    case '9'://ajout all
                        dbSV.addUser(newu);
                        dbSV.addStatistique(news);
                        dbSV.addLocation(newl);
                        dbSV.addHit(newh);
                        break;
                }
                cki = Console.ReadKey();
            }
            Console.WriteLine("Fin programme !!!!");
            Console.ReadKey();
        }
    }
}
