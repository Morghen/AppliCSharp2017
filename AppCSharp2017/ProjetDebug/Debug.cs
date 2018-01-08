using FilmsDAL;
using FilmsDTO;
using FilmsBLL;
using SmartVideoDAL;
using SmartVideoDTOLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SmartVideoBLL;

namespace ProjetDebug
{
    class Debug
    {
        public static int VERSION = 2;
        
        public SmartVideoBLLManager svBll = new SmartVideoBLLManager();
        public static StreamWriter outputfile = new StreamWriter(@"D:\Cours\csharp\StatService\log.txt");
        public static Timer _toMidnightTimer;
        public static Timer _dailyTimer;
        public static string pathfile = @"d:\Cours\csharp\StatService\log.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("=== Outil de test ===");
            //svBll.doStat(DateTime.Today.AddDays(-1));

            try
            {
                _toMidnightTimer = new Timer();
                _toMidnightTimer.AutoReset = false;
                _toMidnightTimer.Elapsed += new ElapsedEventHandler(_toMidnightTimer_Elapsed);

                TimeSpan delay = DateTime.Today.AddDays(1) - DateTime.Now;
                _toMidnightTimer.Interval = delay.TotalMilliseconds;
                Console.WriteLine("delay = " + _toMidnightTimer.Interval + "  --  " + delay);
                _toMidnightTimer.Start();
                //_toMidnightTimer.Enabled = true;
                Console.WriteLine("midnight timer start");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType() + " - " + ex.Message);
            }
            Console.WriteLine("FINI");
            outputfile.WriteLine("hello");
            Console.ReadKey();
            outputfile.Close();



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
        private static void _toMidnightTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Console.WriteLine("midnight timer stop");
                //_db = new SmartVideoBLLManager();
                _dailyTimer = new Timer(86400000); // Correspond a 24h
                _dailyTimer.AutoReset = true;
                _dailyTimer.Elapsed += DailyTimer_Elapsed;
                _dailyTimer.Enabled = true;
                Console.WriteLine("daily timer start");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType() + " - " + ex.Message);
            }
        }

        private static void DailyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Console.WriteLine("time elapsed !");
                if (true)
                {
                    Console.WriteLine("do stat OK");
                }
                else
                {
                    Console.WriteLine("do stat ERREUR");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType() + " - " + ex.Message);
            }
        }
    }
}
