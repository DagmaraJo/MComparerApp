using MComparerApp;
using System.Drawing;
using System.Xml.Linq;

public partial class Program
{
    public static void Main()
    {
        Clear();
        Information();
        bool Exit = false;
        while (!Exit)
        {
            //Background();
            //ChooseComposer();
            //Information();
            //var userInput = Console.ReadLine().ToUpper();
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key )
            {
                case ConsoleKey.A:
                    VoteInMemoryA(); break;
                case ConsoleKey.B:
                    VoteInMemoryB(); break;
                case ConsoleKey.C:
                    ComposersList();
                    string name, secondname, surname;
                    InsertFullName(out name, out secondname, out surname);
                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(secondname) && !string.IsNullOrEmpty(surname))
                    {
                        var composer = new ComposerInFile(name, secondname, surname);
                        composer.NewVoteAdded += NewVoteToFile;
                        TryCatchVote(composer);
                    }
                    else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
                    {
                        var composer = new ComposerInFile(name, surname);
                        composer.NewVoteAdded += NewVoteToFile;
                        TryCatchVote(composer);
                    }
                    else
                    {
                        Attention(53, 30, "    The name and the surname can not be empty!   ");
                        Clear();
                        //continue;
                    }
                    break;
                case ConsoleKey.I :
                    Info(); Console.ReadKey();
                    break;
                case ConsoleKey.S:
                    Console.ResetColor(); Console.BackgroundColor = ConsoleColor.Black; Console.Clear();
                    bool Escape = false;
                    while (!Escape)
                    {
                        if (key.Key != ConsoleKey.Escape)
                        {
                            Menu.StartMenu();
                        }
                    }
                    break;
                case ConsoleKey.Escape:
                    Exit = true;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    
                    Menu.GrayD(20, 36, "press any key to leave\n\n\n");
                    Console.ReadKey();
                    Environment.Exit(0); break;
                default:
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Clear();
                    Info();
                    Attention(60, 44, "      Invalid operation.    \n");
                    Clear();
                    break;//continue;
            }
        }
    }

    static void Clear()
    {
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ReadKey();
        Console.Clear();
        Background();
    }

    static void NewVoteVoid(object sender, EventArgs args)
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.White; 
        Console.Write(" Vote is waiting for approval\n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("       add another one :     ▒ ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    static void NewVoteToFile(object sender, EventArgs args)
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("        Your vote is saved\n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("       add another one :     ▒ ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    static void TryCatchVote(Composer composer)
    {
        VoteWindow();
        Console.SetCursorPosition(2, 5);
        Console.Write("    Write your mark from 1 - 1OO ");
        Console.SetCursorPosition(2, 6);
        Console.Write("  also letters from A - H : _____\n");
        Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒ ");
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "q" || input == "Q")
            {
                composer.ShowResults();
                Console.ReadKey();
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
                Console.Write("\n         ");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("enter correct mark :");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("▒ ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
        }
    }
    static void VoteInMemoryA()
    {
        ComposersList();
        InGreen(58, 17, " A ");
        InGreen(38, 45, " Antonio Luci Vivaldi ");
        VoteWindow();
        Composer composer = new ComposerInMemory("Antonio", "Luci", "Vivaldi");
        composer.NewVoteAdded += NewVoteVoid;
        TryCatchVote(composer);
        Attention(53, 30, "     Remember, this vote will not be saved !     ");
        InfoBlue(38, 34, "                                                                                         ");
        InfoBlue(38, 35, "   If You want to save vote's results, please enter the composer from the list bellowe   ");
        InfoBlue(38, 36, "                                                                                         ");
        Clear();
    }

    static void VoteInMemoryB()
    {
        ComposersList();
        InGreen(94, 17, " B ");
        InGreen(101, 39, " Johan Sebastian Bach ");
        VoteWindow();
        var composer = new ComposerInMemory("Johan","Sebastian" ,"Bach");
        composer.NewVoteAdded += NewVoteVoid;
        TryCatchVote(composer);
        Attention(53, 30, "     Remember, this vote will not be saved !     ");
        InfoBlue(38, 34, "                                                                                         ");
        InfoBlue(38, 35, "   If You want to save vote's results, please enter the composer from the list bellowe   ");
        InfoBlue(38, 36, "                                                                                         ");
        Clear();
    }

    static void InsertFullName(out string name, out string secondname, out string surname)
    {
        InfoGray(57, 27, "   Please insert composer's first name   ");
        Console.SetCursorPosition(49, 34);
        name = Console.ReadLine();

        InfoGray(57, 27, "  Please insert composer's second name.  ");
        Console.SetCursorPosition(72, 34);
        secondname = Console.ReadLine();
        InfoGray(57, 27, "   Please insert composer's last name    ");
        Console.SetCursorPosition(95, 34);
        surname = Console.ReadLine();

      //  Attention(6, 3, $"  Sorry, this Composer {name} {secondname} {surname} does not exist in the system. Everything you do will stay in working memory ");
      //  InfoBlue(38, 30, "       If You want to save vote's results, please chose the composer from the list bellowe        ");
      //  ComposersList();
    }

    static void Attention(int left, int top, string text)
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(left, top);
        Console.Write(text);
    }

    static void InfoGray(int left, int top, string text)
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.SetCursorPosition(left, top);
        Console.WriteLine(text);
    }

    static void InWhite(int left, int top, string text)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.SetCursorPosition(left, top);
        Console.WriteLine(text);
    }

    static void InfoBlue(int left, int top, string text)
    {
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(left, top);
        Console.Write(text);
    }

    static void InGreen(int left, int top, string text) 
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(left, top);
        Console.WriteLine(text);
    }

    public static void Largo( string text, char search, ConsoleColor color)
    {
        Console.CursorVisible = false;
        Console.BackgroundColor = ConsoleColor.Cyan;
        foreach (var letter in text)
        {
            if (letter == search)
            {
                Console.ForegroundColor = color;
                Console.BackgroundColor = ConsoleColor.Cyan;
            }
            else if (letter != search)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Cyan;
            }
            Console.Write(letter);
            Thread.Sleep(70);
        }
        Console.WriteLine();
    }

    static void ChooseComposer()
    {
        InfoGray(53, 25, "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
        InfoGray(53, 26, "░░░░                                         ░░░░");
        InfoGray(53, 27, "░░░░     Choose  Composer       C  ENTER     ░░░░");
        InfoGray(53, 28, "░░░░                                         ░░░░");
        InfoGray(53, 29, "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
    }

    static void Info()
    {
        InfoBlue(41, 37, "     Antonio    Bach    Composers    Info    Survey     Enter     Exit      ");
        InfoBlue(41, 38, "                                                                            ");
        InfoBlue(41, 39, "        A         B         C         I         S         Q        Esc      ");
    }

    static void AntonioBachLabel()
    {
        InWhite(40, 17, "░░░░░░░░░░░░░░░░░░ A ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ B ░░░░░░░░░░░░░░░░░");
        InWhite(40, 18, "░░░░░{                          }░░░░░░░{                          }░░░░░");
        InWhite(40, 19, "░░░░░{   Antonio Luci Vivaldi   }░░░░░░░{   Johan Sebastian Bach   }░░░░░");
        InWhite(40, 20, "░░░░░{    ..................    }░░░░░░░{    ..................    }░░░░░");
    }

    static void Information()
    {
        Console.SetCursorPosition(0, 41);
        Menu.Largo(ConsoleColor.Cyan,"                               . . .  invite you to a special survey on the comparator - DUEL of Champions - enter S  . . .");
        //Console.SetCursorPosition(95, 49);
        //Menu.Largo(ConsoleColor.Cyan,"    press Esc to skip this intro  ");
        Console.SetCursorPosition(0, 14);
        Console.Write("           Try the demo version without saving, use quick access to the most popular ones");
        Console.SetCursorPosition(89, 14);
        Menu.Largo(ConsoleColor.Cyan, "  -  press  A  or  B  . . . .  more info  -  press  I            ");
        AntonioBachLabel();
        Console.SetCursorPosition(103, 25);
        Menu.Largo(ConsoleColor.Cyan, ". . . find your favorite,  ");
        Console.SetCursorPosition(104, 27);
        Menu.Largo(ConsoleColor.Cyan, "        vote for him   ");
        Console.SetCursorPosition(105, 29);
        Menu.Largo(ConsoleColor.Cyan,"     and check the results ");
    }

    static void ComposersList()
    {
        InfoGray(35, 38, "                                                                                                 ");
        InfoGray(35, 39, "    Tomaso Albinoni                 Henry Purcell                  Johan Sebastian Bach          ");
        InfoGray(35, 40, "    Gregorio Allegri                                               Georg Friedrich Haendel       ");
        InfoGray(35, 41, "    Arcangelo Corelli               Grzegorz Gerwazy Gorczycki     Johann Pachelbel              ");
        InfoGray(35, 42, "    Benedetto Marcello              Mikołaj Gomółka                Georg Philipp Telemann        ");
        InfoGray(35, 43, "    Claudio Monteverdi              Adam Jarzębski                 Sylvius Leopold Weiss         ");
        InfoGray(35, 44, "    Jacopo Peri                     Marcin Mielczewski                                           ");
        InfoGray(35, 45, "    Antonio Luci Vivaldi            Bartłomiej Pękiel              Jean-Henri d’Anglebert        ");
        InfoGray(35, 46, "    Domenico Scarlatti              Andrzej Rohaczewski            André Campra                  ");
        InfoGray(35, 47, "    Giovanni Battista Sammartini    Sylwester Szarzyński           François Couperin Le Grand    ");
        InfoGray(35, 48, "    Giuseppe Torelli                Mikołaj Zieleński              Marin Marais                  ");
        InfoGray(35, 49, "                                                                   Jean-Philippe Rameau          ");
    }

    static void Background()
    {
        Console.CursorVisible = false;
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(
          "                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                       ░                                                                                                                   " +
        "\n                                        ░ ░░                   ▒▒▒^^^▬_____<\">____▬^^^▒▒▒                 ░ ░░░░    ░                                    " +
        "\n                                       ░░░░░░░░░           ▒▒▒░░░░░░▒▒▒░░▒▒▒▒▒▒▒░░▒▒▒░░░░░░▒▒▒            ░░░░░░░░░░░░░░                                   " +
        "\n                                 ░░░░░░░░░░░░░░░░            ░░░░░░▒▒▒ ░░▒▒▒▒▒▒▒░░ ▒▒▒░░░░░░             ░░░░░░ ░ ░░░░░░░░░░░                               " +
        "\n                            ░░░░░░░░░  ░░▒▒░░░ ░░░░           ▒▒▒▒▒▒ / ░░░░ ░ ░░░░ \\▒▒▒▒▒▒            ░░░░░░ ░░░░ ░░░░░░  ░░░░░░░░                         " +
        "\n                               ░░░ ░░░░░░░░░░░░░░░░░░,,,,,,░░░▒▒▒▒▒▒░░░░          ░░░░▒▒▒▒▒▒░░,,,,   ░░░░░░░░░░░░░░░░░░░░░░░ ░░                            " +
        "\n                       ░░░░░░░░░ ░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒  ░░░            ░░░  ▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                        " +
        "\n                         ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░░▒▒▒▒▒▒(                     )░▒▒▒▒▒░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                         " +
        "\n                          ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒C___             ___J▒▒▒▒▒▒▒▒ ░░░░░░  ░░░░░░░░░░░░░░░░░░░░░░░░                           " +
        "\n                              ░░░░░░  ░░░░░░░░░░░░░  ░░░░ ░ ▒▒▒▒▒▒▒▒▒▒▒C          J▒▒▒▒▒▒▒▒▒▒▒ ░░░░░░░░░░░░░░░░░░░░░░  ░░░░░░                              " +
        "\n                                        ░░░░░░░░░░░░░░░░▒▒▒▒░░▒▒▒▒▒▒▒▒▒▒▒░      ░▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒░░░░░░░░░░░░░░░░░                                         " +
        "\n                                            ░ ░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░ ░                                            " +
        "\n                                             ░░░    ░▒▒▒▒ ▒▒▒▒▒▒░░                   ░░▒▒▒▒▒▒ ▒▒▒▒▒▒░    ░░░                                               " +
        "\n                                                    ▒▒▒▒▒▒▒▒▒░░░                          ░░▒▒▒▒▒▒▒▒▒▒                                                     " +
        "\n                                                     ▒▒▒▒▒▒                                   ▒▒▒▒▒▒                                                       " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                         W E L C O M E   T O   T H E   S P E A C E   O F  B A R O Q U E   M U S I C                                        " +
        "\n                                                __________________________________________________________                                                 " +
        "\n                               ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                               " +
        "\n                                                       ^^^^▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒^^^^                                                        " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                      ^^▒▒▒▒▒░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░░░░░░░░░░░░░▒▒▒▒▒^^                                      " +
        "\n                                   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▬▬▬▀▀▀▀▀▬▬▬▒▒▒▒▒▒▒▒▒▒▒▒****▬▬▬****▒▒▒▒▒▒▒▒▒▒▒▒▬▬▬▀▀▀▀▀▬▬▬▒▒▒▒▒▒▒▒▒▒▒▒▒▒                                   " +
        "\n                                     ░░░░░░░░░░░             ░░░░░░░░░░             ░░░░░░░░░░             ░░░░░░░░░░░                                     " +
        "\n                                      ▒▒▒▒▒▒▒▒▒               ▒▒▒▒▒▒▒▒               ▒▒▒▒▒▒▒▒               ▒▒▒▒▒▒▒▒▒                                      " +
        "\n                                 ░░░░░░░░░░░░░   ,,,,,,,,,,,,  ░░░░░░   ,,,,,,,,,,,   ░░░░░░  ,,,,,,,,,,,,   ░░░░░░░░░░░░░                                 " +
        "\n                                                      ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                                                      " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n       ░░░░░░░░░░░░░░░░░                                                                                                              ░░░░░░░░░░░░░░░░░    " +
        "\n                                                                                                                                                           " +
        "\n       ░░░░░░░░░░░░░░░░░                                                                                                              ░░░░░░░░░░░░░░░░░    " +
        "\n       ░░░░░░░░░░░░░░░░░                                                                                                              ░░░░░░░░░░░░░░░░░    " +
        "\n       ░░░░░░░░░░░░░░░░░                           Compare music and vote for your favourite classical pices.                         ░░░░░░░░░░░░░░░░░    " +
        "\n       ░░░░░░░░░░░░░░░░░                                                                                                              ░░░░░░░░░░░░░░░░░    " +
        "\n       ░░░░░░░░░░░░░░░░░                      Take part in researching the work of the most outstanding composers.                    ░░░░░░░░░░░░░░░░░    " +
        "\n       ░░░░░░░░░░░░░░░░░                                                                                                              ░░░░░░░░░░░░░░░░░    " +
        "\n       ░░░░░░░░░░░░░░░░░                                                                                                              ░░░░░░░░░░░░░░░░░    " +
        "\n       ░░░░░░░░░░░░░░░░░                                                                                                              ░░░░░░░░░░░░░░░░░    " +          
        "\n       ░░░░░░░░░░░░░░░░░                                            ________<\">________                                               ░░░░░░░░░░░░░░░░░    " +
        "\n       ░░░░░░░░░░░░░░░░░                                                                                                              ░░░░░░░░░░░░░░░░░    " +
        "\n       ░░░░░░░░░░░░░░░░░░░░░░░░░░░░                                                                                      ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░    " +
        "\n       ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░((((((((                                          ))))))))░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░    " +
        "\n     ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  " +
        "\n   ░░░░░░░░░░░░░░░░░░░░░░░░                                                                                                     ░░░░░░░░░░░░░░░░░░░░░░░░░░░ " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " +
        "\n                                                                                                                                                           " );

        //InfoBlue(0, 40,
        //  "   ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░                             Compare music and vote for your favourite classical pices.                           ░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░                        Take part in researching the work of the most outstanding composers.                      ░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░                                                ________<\">________                                               ░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░░░░░░░░░░░░                                                                                            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░((((((((                                            ))))))))░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
        //  "   ░░░░░░░░░░░░░░░░░░░░░░░░                                                                                                    ░░░░░░░░░░░░░░░░░░░░░░░░░░░\n");

        ChooseComposer();
        Console.SetCursorPosition(76,12);
    }

    static void VoteWindow()
    {
        InfoGray(0,4,
              "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒     ▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒     ▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒     ▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒     ▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒     ▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒     ▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒     ▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒     ▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒     ▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒     ▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒" +
            "\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒" +
            "\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒" +
            "\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒" +
            "\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒" +
            "\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒" +
            "\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
    }
}

    





    





