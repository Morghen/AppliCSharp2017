﻿using FilmsDAL;
using FilmsDTO;
using FilmsBLL;
using SmartVideoDAL;
using SmartVideoDTOLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartVideoBLL;

namespace ProjetDebug
{
    class Debug
    {
        public static int VERSION = 2;
        static void Main(string[] args)
        {
            Console.WriteLine("=== Outil de test ===");
            SmartVideoBLLManager svBll = new SmartVideoBLLManager();
            svBll.doStat(DateTime.Today.AddDays(-1));
            Console.WriteLine("FINI");
            Console.ReadKey();



            /*
            Console.WriteLine("+++Test de Hit+++ "+Environment.MachineName);
            SmartVideoBLLManager svBll = new SmartVideoBLLManager();
            SmartVideoDALManager dbSV = svBll.svDal;
            
           
            // creation des objets de test
            UserDTO newu = new UserDTO("user", "user", "user");
            HitDTO newh = new HitDTO(11, TypeEnum.Film, DateTime.Today, 45);
            //LocationDTO newl = new LocationDTO(112, 11, "Star Wars episode IV", DateTime.Today, (DateTime.Today).AddDays(5), "user");
            StatistiqueDTO news = new StatistiqueDTO(11, TypeEnum.Film, DateTime.Today, 1);

            //recupere les objet dans la BD
            List<HitDTO> listHit;
            List<StatistiqueDTO> listStat;
            List<UserDTO> listUser;
            List<LocationDTO> listLoca;

            Console.WriteLine("Liste Film");

            FilmsBLLManager bll = new FilmsBLLManager();
            */

            /*
             * FilmDTO testF = dbF.getFilm(11);

            List<string> info = bll.getFilmInfos(testF);
            foreach(String str in info)
            {
                Console.WriteLine(str);
            }
            */

            /*
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
                        //dbSV.addLocation(newl);
                        break;
                    case '4'://ajout hit
                        //svBll.incHitFilm(11);
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
                        //dbSV.addLocation(newl);
                        break;
                }
                cki = Console.ReadKey();
            }
            Console.WriteLine("Fin programme !!!!");
            Console.ReadKey();
            */
        }
    }
}
