using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComparerApp
{
    static class Menu
    {
        readonly static string[] positionsMenu = {
          "\n                                                                 V O T E    " +
          "\n                                                                    &       " +
          "\n                                                              R A N K I N G " ,
          "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
            "                                                         BWV 593    ▲    RV 522",
            "                                                         BWV 594    ▼    RV 208",
            "                                                         BWV 596    -    RV 565",
          "\n                                                           BWV 972  -  RV 230",
            "                                                           BWV 973  -  RV 299",
            "                                                           BWV 975  -  RV 316a",
            "                                                           BWV 976  -  RV 265",
            "                                                           BWV 977  -  RV ?",
            "                                                           BWV 978  -  RV 310",
            "                                                           BWV 979  -  RV 318    /  RV Anh.10 Vivaldi  =>   Torelli ?",
            "                                                           BWV 980  -  RV 381",
          "\n                                                         BWV 1065   ▼   RV 580",
      "\n\n\n                                                                 E X I T   " };
        static int activePositionMenu = 0;

        public static void StartMenu()
        {
            while (true)
            {
                ShowMenu();
                SelectOptions();
                RunOptions();
            }
        }

        public static void ShowMenu()
        {
            var composer1 = new ComposerInMemory("Johan", "Sebastian", "Bach", "( 1685 - 1750 )");
            var composer2 = new ComposerInMemory("Antonio", "Lucio", "Vivaldi", "( 1678 - 1741 )");
            Console.SetCursorPosition(19, 17);
            Console.WriteLine(composer1.FullName);
            Console.SetCursorPosition(100, 17);
            Console.WriteLine(composer2.FullName);
            Gray(21, 18, composer1.Age);
            Gray(103, 18, composer2.Age);
            Gray(59, 24, "Select concertos");
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < positionsMenu.Length; i++)
            {
                if (i == activePositionMenu)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(positionsMenu[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.WriteLine(positionsMenu[i]);
                }
            }
        }
        static void SelectOptions()
        {
            do
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    activePositionMenu = (activePositionMenu > 0) ? activePositionMenu - 1 : positionsMenu.Length - 1;
                    ShowMenu();
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    activePositionMenu = (activePositionMenu + 1) % positionsMenu.Length;
                    ShowMenu();
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    activePositionMenu = positionsMenu.Length - 1; break; 
                }
            } while (true);
        }
        static void RunOptions()
        {
            switch (activePositionMenu)
            {
                case 0: VoteInMemory(); break; 
                case 1: Lab(); Label1(); Tag1(); break;
                case 2: Lab(); Label2(); Tag2(); break;
                case 3: Lab(); Label3(); Tag3(); break;
                case 4: Lab(); Label4(); Tag4(); break;
                case 5: Lab(); Label5(); Tag5(); break;
                case 6: Lab(); Label6(); Tag6(); break;
                case 7: Lab(); Label7(); Tag7(); break;
                case 8: Lab(); Label8(); Tag8(); break;
                case 9: Lab(); Label9(); Tag9(); break;
                case 10: Lab(); Label10(); Tag10(); break;
                case 11: Lab(); Label11(); Tag11(); break;
                case 12: Lab(); Label12(); Tag12(); break;
                case 13: break; //Environment.Exit(0);
            }
        }

        public static void VoteInMemory()
        {
            var composer = new ComposerInMemory("Johan", "Sebastian", "Bach");
            composer.VoteAdded += ComposerInMemoryVoteAdded;
            void ComposerInMemoryVoteAdded(object sender, EventArgs args)
            {
                Console.Write("       Your vote is waiting for approval \n," +
                    "\n     add another one :        ");
            }
            //composer.VoteMax += ComposerInMemoryVoteMax;
            //void ComposerInMemoryVoteMax(object sender, EventArgs args)
            //{
            //    Console.Write($" +             max mark for Bach !" + "\n\n     add another one :        ");
            //}
            //composer.VoteMin += VoteMinComposer;
            //void VoteMinComposer(object sender, EventArgs args)
            //{
            //    Console.Write($" +           max mark for Vivaldi !" + "\n\n     add another one :        ");
            //}
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 5);
            Console.Write("    Write your mark :        ");
            while (true)
            {
                var statistics = composer.GetStatistics();
                //var maxgrade = composer.CountMax();
                //var minVote = composer.CountMin();
                var input = Console.ReadLine(); 
                if (input == "q")
                {
                    //var statistics = composer.GetStatistics();
                    //composer.CountMax();
                    Console.WriteLine("...............................................");
                    Console.WriteLine("\n------------------------------------------");
                    Console.WriteLine($"  total  V O T E S :   {statistics.Count} ");
                    Console.WriteLine($"\n  {composer.FullName.ToUpper()} --------------");
                    Console.WriteLine("________________________ R E S U L T S ______");
                    Console.WriteLine($"      Total marks :  {statistics.Sum:N2} ");
                    Console.WriteLine($"          Average :  {statistics.Average:N2}");
                    Console.WriteLine($"              Max :  {statistics.Max}");
                    Console.WriteLine($"              Min :  {statistics.Min}");
                    break;
                }
                try
                {
                    composer.AddGrade(input);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{ex.Message}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\n,\n     add another one :        ");
                }
            }
        }

        public static void Gray(int left, int top, string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(text);
        }
        public static void GrayD(int left, int top, string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(text);
        }

        static void Lab()
        {
            GrayD(15, 23, "/ for organ or harpsichord /");
            GrayD(21, 24, "nowaday for piano");
            GrayD(18, 26, "Allegro, Largo, Allegro");
            GrayD(88, 23, "/ for solo violin, strings and basso continuo /");
        }

        static void Label1()
        {
            Gray(13, 21, "Organ Concerto In A minor, BWV 593");
            GrayD(17, 26, "Allegro, Adagio, Allegro");
        }
        static void Label2()
        {
            Gray(13, 21, "Organ Concerto In C Major, BWV 594");
            GrayD(13, 26, "Allegro, Recitativ Adagio, Allegro");
        }
        static void Label3()
        {
            Gray(13, 21, "Organ Concerto In D minor, BWV 596");
            GrayD(13, 26, "Adagio Grave, Fuge, Largo, Finale");
        }
        static void Label4()
        {
            Gray(10, 21, "Harpsichord Concerto In D Major, BWV 972");
            GrayD(16, 26, "Allegro, Larghetto, Allegro");
        }
        static void Label5()
        {
            Gray(10, 21, "Harpsichord Concerto In G Major, BWV 973");
        }
        static void Label6()
        {
            Gray(10, 21, "Harpsichord Concerto In G minor, BWV 975");
            GrayD(16, 26, "Allegro, Largo, Giga Presto");
        }
        static void Label7()
        {
            Gray(10, 21, "Harpsichord Concerto In C Major, BWV 976");
        }
        static void Label8()
        {
            Gray(10, 21, "Harpsichord Concerto In C Major, BWV 977");
            GrayD(15, 26, "Allegro, Adagio, Giga Presto");
        }
        static void Label9()
        {
            Gray(10, 21, "Harpsichord Concerto In F Major, BWV 978");
        }
        static void Label10()
        {
            Gray(10, 21, "Harpsichord Concerto In B minor, BWV 979");
            GrayD(17, 26, "Allegro, Adagio, Allegro");
        }
        static void Label11()
        {
            Gray(10, 21, "Harpsichord Concerto In G Major, BWV 980");
        }
        static void Label12()
        {
            Gray(6, 21, "Concerto for 4 harpsichords In A minor, BWV 1065");
            GrayD(6, 23, "/ for harpsichords, strings, and basso continuo /");
        }

        static void Tag1()
        {
            Gray(97, 21, "Concerto in A minor, RV 522");
            GrayD(94, 23, "two violins");
            GrayD(91, 24, "Op. 3 No. 8, from \"L'estro Armonico\" 1711");
            GrayD(92, 26, "Allegro, Larghetto e spiritoso, Allegro");
            Console.ReadKey(); Console.Clear();
        }
        static void Tag2()
        {
            Gray(87, 21, "Concerto in D Major \"Il Grosso Mogul\", RV 208");
            GrayD(104, 24, "Op.7 No.11"); // also 208 a, Op.7 No.11
            GrayD(92, 26, "Allegro, Grave Recitativo, Allegro");
        }
        static void Tag3()
        {
            Gray(94, 21, "Concerto Grosso in D minor, RV 565");
            GrayD(84, 23, "/ for 2 violins and cello, strings and basso continuo /");
            GrayD(91, 24, "Op. 3 No. 11 from \"L'estro Armonico\" 1711");
            GrayD(92, 26, "Allegro, Adagio, Allegro, Largo, Allegro");
        }
        static void Tag4()
        {
            Gray(97, 21, "Concerto in D Major, RV 230");
            GrayD(91, 24, "Op. 3 No. 9 from \"L'estro Armonico\" 1711");
            GrayD(97, 26, "Allegro, Larghetto, Allegro");
        }
        static void Tag5()
        {
            Gray(97, 21, "Concerto in G Major, RV 299");
            GrayD(104, 24, "Op. 7 No. 8");
            GrayD(90, 26, "Allegro assai, Larghetto staccato, Allegro");
        }
        static void Tag6()
        {
            Gray(97, 21, "Concerto in G Major, RV 316a");
            GrayD(92, 24, "Op. 4 No. 6 from \"La stravaganza\" 1716");
            GrayD(99, 26, "Allegro, Largo, Allegro");
        }
        static void Tag7()
        {
            Gray(97, 21, "Concerto in E major, RV 265");
            GrayD(91, 24, "Op. 3 No. 12 from \"L'estro Armonico\" 1711");
            GrayD(93, 26, "Allegro, Largo e molto acuto, Allegro");
        }
        static void Tag8()
        {
            Gray(87, 23, "There is highly probably lost Concerto in D Major");
        }
        static void Tag9()
        {
            Gray(97, 21, "Concerto in G Major, RV 310");
            GrayD(91, 24, "Op. 3 No. 3 from \"L'estro Armonico\" 1711");
            GrayD(99, 26, "Allegro, Largo, Allegro");
        }
        static void Tag10()
        {
            Gray(97, 21, "Concerto in G minor, RV 318");
            GrayD(104, 24, "Op. 6 No. 3");
            GrayD(99, 26, "Allegro, Adagio, Allegro");
        }
        static void Tag11()
        {
            Gray(97, 21, "Concerto in B Major, RV 381");
            GrayD(92, 24, "Op. 4 No. 6 from \"La stravaganza\" 1716");
            GrayD(99, 26, "Allegro, Adagio, Allegro");
        }
        static void Tag12()
        {
            Gray(91, 21, "Concerto for 4 violins in B minor, RV 580");
            GrayD(83, 23, "/ for 4 violins, 2 violas, cello, strings and basso continuo /");
            GrayD(91, 24, "Op. 3 No. 10 from \"L'estro Armonico\" 1711");
            GrayD(87, 26, "Allegro, Largo - Larghetto – Adagio F♯ – Largo, Allegro");
        }
    }
}
