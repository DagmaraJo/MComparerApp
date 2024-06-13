namespace MComparerApp
{
    static class Menu
    {
        readonly static string[] positionsMenu = {
          "\n                                                                         V O T E    " +
          "\n                                                                            &       " +
          "\n                                                                      R A N K I N G " ,
          "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
            "                                                                 BWV 593    ▲    RV 522",
            "                                                                 BWV 594    ▼    RV 208",
            "                                                                 BWV 596    -    RV 565",
          "\n                                                                   BWV 972  -  RV 230",
            "                                                                   BWV 973  -  RV 299",
            "                                                                   BWV 975  -  RV 316a",
            "                                                                   BWV 976  -  RV 265",
            "                                                                   BWV 977  -  RV ?",
            "                                                                   BWV 978  -  RV 310",
            "                                                                   BWV 979  -  RV 318    /  RV Anh.10 Vivaldi  =>   Torelli ?",
            "                                                                   BWV 980  -  RV 381",
          "\n                                                                 BWV 1065   ▼   RV 580",
      "\n\n\n                                                                         E X I T   " };
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            var composer1 = new ComposerInMemory("Johan", "Sebastian", "Bach", "( 1685 - 1750 )");
            var composer2 = new ComposerInMemory("Antonio", "Lucio", "Vivaldi", "( 1678 - 1741 )");
            Write(ConsoleColor.White, 19, 17, composer1.FullName);
            Write(ConsoleColor.White, 110, 17, composer2.FullName);
            Write(ConsoleColor.Gray, 21, 18, composer1.Age);
            Write(ConsoleColor.Gray, 113, 18, composer2.Age);
            Write(ConsoleColor.Gray, 67, 24, "Select concertos");
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
                case 0: Vote(); break; 
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
                case 13: Program.Main(); break;
            }
        }

        static void NewVoteInSurvey(object sender, EventArgs args)
        {
            Console.Write("       Your vote is saved\n");
        }

        static void Vote()
        {
            Write(ConsoleColor.Gray, 7, 14, "Press  B   if you want to give marks to Bach");
            Write(ConsoleColor.Gray, 100, 14, " Press  V   if you want to give marks to Vivaldi");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.B)
            {
                var composer1 = new ComposerInSurvey("Johan", "Sebastian", "Bach");
                composer1.NewVoteAdded += NewVoteInSurvey;
                VoteInSurvey(composer1);
            }
            else if (key.Key == ConsoleKey.V)
            {
                var composer2 = new ComposerInSurvey("Antonio", "Luci", "Vivaldi");
                composer2.NewVoteAdded += NewVoteInSurvey;
                VoteInSurvey(composer2);
            }
        }

        public static void VoteInSurvey(Composer composer)
        {
            Survey();
            Console.ForegroundColor = ConsoleColor.Cyan;
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "q" || input == "Q")
                {
                    composer.ShowResults();

                    Console.SetCursorPosition(50, 37);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write( "                                       ");
                    Console.SetCursorPosition(52, 37);
                    WriteSlowly(ConsoleColor.Black,"                     Thank you for participating in the survey.        ");
                    Write(ConsoleColor.White, 52, 39, "                             press any key to return");
                    Console.ReadKey();
                    Console.Clear();
                    
                    break;
                }
                try
                {
                    composer.AddGrade(input.ToUpper());
                    Console.Write("\n     add another one :        ");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{ex.Message}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\n     add another one :        ");
                }
            }
        }

        public static void Survey()
        {
            Console.Clear();
            Write(ConsoleColor.Gray, 10, 2, "In a moment you will read strongly divided opinions from S - Z about the presented concertos. If you agree with the following sentences,");
            Console.SetCursorPosition(30, 3);
            WriteSlowly(ConsoleColor.Black, "                       please enter the letter with ' + ' , but if you not agree add ' - '  to this letter.    ");

            BulletPoint(47, 5, "███████████");
            WriteYellowD(6, "  S    J.S.Bach turned Vivaldi's ordinary concertos into masterpieces.");
            WriteYellowD(7, "    █  His skill makes them deserving of being considered completely original compositions.");
            WriteYellowD(8, "    █  It's without a question Bach's original composition from start to finish.");
            BulletPoint(47, 9, "███████████");
            WriteYellowD(10, "  T    These concertos are entirely different, vary in tonation and melody, Bach seems more complex.");
            WriteYellowD(11, "    █  Who knows, maybe it was Vivaldi who got inspiration from master Johann?");
            BulletPoint(47, 12, "███████████");
            WriteYellowD(13, "  U    Bach's transcriptions are proof of his incredible musical talent, putting a whole orchestra");
            WriteYellowD(14, "    █  into one instrument is really brilliant ! And to be able to play it too !! Just genius !");
            BulletPoint(47, 15, "███████████");
            WriteYellowD(16, "  V    You can't say he just transcribed it, he rewrote them creatively, he gave it new life !");
            WriteYellowD(17, "    █  Bach improved Vivaldi's simple melodies, added baroque ornaments, more skill, gor rid of");
            WriteYellowD(18, "    █  unnecessery fragments. The effect is a completely different piece, with its own character.");
            BulletPoint(47, 19, "███████████");
            WriteYellowD(20, "  W    Bach only rewrote the original, partially changing the fragments made for violins amd impossible");
            WriteYellowD(21, "    █  to play on harpsichord. Unfortunatly not for the better, just comes down to technical show-off.");
            WriteYellowD(22, "    █  In the case of these concertos, Bach was indeed just a copy writer.");
            BulletPoint(47, 23, "███████████");
            WriteYellowD(24, "  X    I love Vivaldi's original compositions, there's something annoying in Bach's transcriptions,");
            WriteYellowD(25, "    █  they are not whole. It's chaos without leading solos and depth other instruments in the background.");
            BulletPoint(47, 26, "███████████");
            WriteYellowD(27, "  Y    I'm pretty surprised, I always thought it was Bach's original composition !");
            WriteYellowD(28, "    █  It's strange that there is lack of information that this concerto is after Vivaldi.");
            WriteYellowD(29, "    █  It should be signed better because it confuses people.");
            BulletPoint(47, 30, "███████████");
            WriteYellowD(31, "  Z    It's a known fact that Bach rewrote these concertos to popularise italian music in Germany. ");
            WriteYellowD(32, "    █  His versions are relatively easy to play, many of them are transcribed for home harpsichord.");

            Write(ConsoleColor.Gray, 50, 37, $"To leave and show statistics enter 'q'.");
            Write(ConsoleColor.Cyan, 0, 5, "     Express your opinion from  1 - 1OO" +
                "\n   you can also use the letters A - H" +
                "\n    or markings from the survey\n\n");
            Console.Write("    Write your grade :        ");
        }

        static void WriteYellowD(int top, string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(43, top);
            Console.WriteLine(text);
        }

        public static void WriteSlowly(ConsoleColor color, string text)
        {
            Console.CursorVisible = false;
            foreach (var letter in text)
            {
                Console.BackgroundColor = color;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(letter);
                Thread.Sleep(45);
            }
            Console.WriteLine();
        }

        public static void BulletPoint(int left, int top, string text)
        {
            Console.CursorVisible = false;
            foreach (var letter in text)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(left, top);
                Console.Write(letter);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        public static void Write( ConsoleColor color,int left, int top, string text)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(text);
        }

        static void Lab()
        {
            Write(ConsoleColor.Gray, 6, 21, "                                                 ");
            Write(ConsoleColor.DarkGray,6, 23, "         / for organ or harpsichord /            ");
            Write(ConsoleColor.DarkGray, 6, 24, "               nowaday for piano                 ");
            Write(ConsoleColor.DarkGray, 6, 26, "            Allegro, Largo, Allegro              ");
            Write(ConsoleColor.DarkGray, 93, 23, "     / for solo violin, strings and basso continuo /          ");
            Write(ConsoleColor.DarkGray, 97, 26, "            Allegro, Adagio, Allegro                ");
        }

        static void Label1()
        {
            Write(ConsoleColor.Gray, 10, 21, "   Organ Concerto In A minor, BWV 593   ");
            Write(ConsoleColor.DarkGray, 17, 26, "Allegro, Adagio, Allegro");
        }
        static void Label2()
        {
            Write(ConsoleColor.Gray, 10, 21, "   Organ Concerto In C Major, BWV 594   ");
            Write(ConsoleColor.DarkGray, 13, 26, "Allegro, Recitativ Adagio, Allegro");
        }
        static void Label3()
        {
            Write(ConsoleColor.Gray, 10, 21, "   Organ Concerto In D minor, BWV 596   ");
            Write(ConsoleColor.DarkGray, 13, 26, "Adagio Grave, Fuge, Largo, Finale ");
        }
        static void Label4()
        {
            Write(ConsoleColor.Gray, 10, 21, "Harpsichord Concerto In D Major, BWV 972");
            Write(ConsoleColor.DarkGray, 16, 26, "Allegro, Larghetto, Allegro");
        }
        static void Label5()
        {
            Write(ConsoleColor.Gray, 10, 21, "Harpsichord Concerto In G Major, BWV 973");
        }
        static void Label6()
        {
            Write(ConsoleColor.Gray, 10, 21, "Harpsichord Concerto In G minor, BWV 975");
            Write(ConsoleColor.DarkGray, 16, 26, "Allegro, Largo, Giga Presto");
        }
        static void Label7()
        {
            Write(ConsoleColor.Gray, 10, 21, "Harpsichord Concerto In C Major, BWV 976");
        }
        static void Label8()
        {
            Write(ConsoleColor.Gray, 10, 21, "Harpsichord Concerto In C Major, BWV 977");
            Write(ConsoleColor.DarkGray, 15, 26, "Allegro, Adagio, Giga Presto");
        }
        static void Label9()
        {
            Write(ConsoleColor.Gray, 10, 21, "Harpsichord Concerto In F Major, BWV 978");
        }
        static void Label10()
        {
            Write(ConsoleColor.Gray, 10, 21, "Harpsichord Concerto In B minor, BWV 979");
            Write(ConsoleColor.DarkGray, 17, 26, "Allegro, Adagio, Allegro");
        }
        static void Label11()
        {
            Write(ConsoleColor.Gray, 10, 21, "Harpsichord Concerto In G Major, BWV 980");
        }
        static void Label12()
        {
            Write(ConsoleColor.Gray, 6, 21, "Concerto for 4 harpsichords In A minor, BWV 1065");
            Write(ConsoleColor.DarkGray, 6, 23, "/ for harpsichords, strings, and basso continuo /");
        }

        static void Tag1()
        {
            Write(ConsoleColor.Gray, 97, 21, "          Concerto in A minor, RV 522         ");
            Write(ConsoleColor.DarkGray, 93, 23, "     / for two violins");
            Write(ConsoleColor.DarkGray, 101, 24, "Op. 3 No. 8, from \"L'estro Armonico\" 1711");
            Write(ConsoleColor.DarkGray, 102, 26, "Allegro, Larghetto e spiritoso, Allegro");
        }
        static void Tag2()
        {
            Write(ConsoleColor.Gray, 97, 21, "Concerto in D Major \"Il Grosso Mogul\", RV 208");
            Write(ConsoleColor.DarkGray, 101, 24, "             Op.7 No.11                     ");
            Write(ConsoleColor.DarkGray, 102, 26, "Allegro, Grave Recitativo, Allegro");
        }
        static void Tag3()
        {
            Write(ConsoleColor.Gray, 97, 21, "       Concerto Grosso in D minor, RV 565      ");
            Write(ConsoleColor.DarkGray, 94, 23, "/ for 2 violins and cello, strings and basso continuo /");
            Write(ConsoleColor.DarkGray, 101, 24, "Op. 3 No. 11 from \"L'estro Armonico\" 1711");
            Write(ConsoleColor.DarkGray, 102, 26, "Allegro, Adagio, Allegro, Largo, Allegro");
        }
        static void Tag4()
        {
            Write(ConsoleColor.Gray, 97, 21, "          Concerto in D Major, RV 230          ");
            Write(ConsoleColor.DarkGray, 101, 24, "Op. 3 No. 9 from \"L'estro Armonico\" 1711");
            Write(ConsoleColor.DarkGray, 107, 26, "Allegro, Larghetto, Allegro");
        }
        static void Tag5()
        {
            Write(ConsoleColor.Gray, 97, 21, "          Concerto in G Major, RV 299          ");
            Write(ConsoleColor.DarkGray, 101, 24, "             Op. 7 No. 8                    ");
            Write(ConsoleColor.DarkGray, 100, 26, "Allegro assai, Larghetto staccato, Allegro");
        }
        static void Tag6()
        {
            Write(ConsoleColor.Gray, 97, 21, "          Concerto in G Major, RV 316a          ");
            Write(ConsoleColor.DarkGray, 101, 24, "   Op. 4 No. 6 from \"La stravaganza\" 1716   ");
            Write(ConsoleColor.DarkGray, 109, 26, "Allegro, Largo, Allegro  ");
        }
        static void Tag7()
        {
            Write(ConsoleColor.Gray, 97, 21, "          Concerto in E major, RV 265           ");
            Write(ConsoleColor.DarkGray, 101, 24, "Op. 3 No. 12 from \"L'estro Armonico\" 1711");
            Write(ConsoleColor.DarkGray, 103, 26, "Allegro, Largo e molto acuto, Allegro   ");
        }
        static void Tag8()
        {
            Write(ConsoleColor.Gray, 97, 21, "                                               ");
            Write(ConsoleColor.DarkGray, 93, 23, "                                                              ");
            Write(ConsoleColor.Gray, 101, 24, "  highly probably lost Concerto in D Major    ");
            Write(ConsoleColor.DarkGray, 109, 26, "                         ");
        }
        static void Tag9()
        {
            Write(ConsoleColor.Gray, 97, 21, "         Concerto in G Major, RV 310           ");
            Write(ConsoleColor.DarkGray, 101, 24, "Op. 3 No. 3 from \"L'estro Armonico\" 1711    ");
            Write(ConsoleColor.DarkGray, 109, 26, "Allegro, Largo, Allegro  ");
        }
        static void Tag10()
        {
            Write(ConsoleColor.Gray, 97, 21, "         Concerto in G minor, RV 318            ");
            Write(ConsoleColor.DarkGray, 101, 24, "             Op. 6 No. 3                      ");
            Write(ConsoleColor.DarkGray, 109, 26, "Allegro, Adagio, Allegro");
        }
        static void Tag11()
        {
            Write(ConsoleColor.Gray, 97, 21, "         Concerto in B Major, RV 381            ");
            Write(ConsoleColor.DarkGray, 101, 24, " Op. 4 No. 6 from \"La stravaganza\" 1716   ");
            Write(ConsoleColor.DarkGray, 109, 26, "Allegro, Adagio, Allegro");
        }
        static void Tag12()
        {
            Write(ConsoleColor.Gray, 101, 21, "Concerto for 4 violins in B minor, RV 580");
            Write(ConsoleColor.DarkGray, 93, 23, "/ for 4 violins, 2 violas, cello, strings and basso continuo");
            Write(ConsoleColor.DarkGray, 101, 24, "Op. 3 No. 10 from \"L'estro Armonico\" 1711");
            Write(ConsoleColor.DarkGray, 97, 26, "Allegro, Largo - Larghetto – Adagio – Largo, Allegro");
        }
    }
}
