using MComparerApp;
using System.Drawing;
using System.Xml.Linq;

static void ComposerVoteAdded(object sender, EventArgs args)
{
    //Attention(45, 4, "      Remember, Your vote will not be saved !        ");
    Console.Write("  Your vote is waiting for approval \n," +
        "     add another one :        ");
}

//Composer composer1 = new ComposerInMemory("Johan", "Sebastian", "Bach");
//Composer composer2 = new ComposerInMemory("Antonio", "Luci", "Vivaldi");
//Composer composer3 = new ComposerInMemory("Alessandro","Marcello");
Console.CursorVisible = false;
Console.BackgroundColor = ConsoleColor.Cyan;
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.ReadKey();

StartVote();

static void StartVote()
{
    Background();
    ConsoleKeyInfo key = Console.ReadKey();
    bool Exit = false;
    while (!Exit)
    {
        ////Info();
        //Console.SetCursorPosition(0,1);
        //Console.Write("    What you want to do? \n" +
        //              " Press key C (A - B), M or X     ");
        Background();
        ChooseComposer();
        var userInput = Console.ReadLine().ToUpper();

        switch (userInput)
        {
            case "A":
                VoteInMemoryA(); break;
            case "B":
                VoteInMemoryB(); break;
            case "C":
                ChooseComposer();
                string name, secondname, surname;
                InsertFullName(out name, out secondname, out surname);
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(secondname) && !string.IsNullOrEmpty(surname))
                {
                    var composer = new ComposerInMemory(name, secondname, surname);
                    composer.VoteAdded += ComposerVoteAdded;
                    TryCatchVote(composer);
                }
                else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
                {
                    var composer = new ComposerInMemory(name, surname);
                    composer.VoteAdded += ComposerVoteAdded;
                    TryCatchVote(composer);
                }
                else
                {
                    Attention(64, 30, "    The name and surname can not be empty!   ");
                    Console.ReadKey(); 
                    InfoGray(64, 30, "                                                          ");
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(57, 10);
                    Console.Write( "                                                          ");
                }
                break;
                //break;
            //case "F":
            //    Menu.StartMenu();    // InFile
            //    break;
            case "I":
                Info();
                break;
            //case "M":
            //    Background();
            //    bool Escape = false;
            //    while (!Escape)
            //    {
            //        if (key.Key != ConsoleKey.Escape)
            //        {
            //            Menu.StartMenu();
            //        }
            //    }
            //    break;
            case "X":
                Exit = true;
                Environment.Exit(0); break;
            default:
                InfoBlue( 6, 20,"      Invalid operation.    \n");
                continue;
        }
    }
    Console.WriteLine("\n\n  Da capo al fine ? \n\n     Press any key to leave.");
    Console.ReadKey();
   

    Menu.Gray(5,9,"ok");

    static void InsertFullName(out string name, out string secondname, out string surname)
    {
        ChooseComposer();


        //InfoWhite(25, "░░░░░░░░░░░░░░░░░░░░░ A ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ B ░░░░░░░░░░░░░░░░░░░░░░");
        //InfoWhite(26, "░░░░░░░░░{                          }░░░░░░░{                          }░░░░░░░░░");
        //InfoWhite(27, "░░░░░░░░░{   Antonio Luci Vivaldi   }░░░░░░░{   Johan Sebastian Bach   }░░░░░░░░░");
        //InfoWhite(28, "░░░░░░░░░{    ..................    }░░░░░░░{    ..................    }░░░░░░░░░");

        

        InfoGray(48,30,  "Please insert composer's first name");
        Console.SetCursorPosition(50,26); //51
        name = Console.ReadLine();

        InfoGray(48,30,  "             Please insert composer's second name");
        Console.SetCursorPosition(71, 26);
        secondname = Console.ReadLine();
        InfoGray(48,30, "                                  Please insert composer's last name");
        Console.SetCursorPosition(96, 26);
        surname = Console.ReadLine();

        InGreen(0, 2,
        "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
      "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
      "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");

        Attention( 6,3, $"  Sorry, this Composer {name} {secondname} {surname} does not exist in the system. Everything you do will stay in working memory ");
        InfoBlue(38, 30, "       If You want to save vote's results, please chose the composer from the list bellowe        ");
        ComposersList();
    }
}

static void TryCatchVote(Composer composer)
{
    VoteWindow();
    //string name = null;
    //string secondname = null;
    //string surname = null;
    ////var composer1 = new ComposerInMemory(name, surname);
    ////string name2 = null;
    ////string surname2 = null; 
    //var composer = new ComposerInMemory(name, secondname, surname);
    //composer.VoteAdded += ComposerInMemoryVoteAdded;
    Console.SetCursorPosition(0, 5);
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write("       Write your mark from 1 - 1OO \n" +
                  " also letters from  A - H :         9\n" +
                  "                              ");
    Console.ForegroundColor = ConsoleColor.White;
    while (true)
    {
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            composer.MemoryFullNameStringBuilder();
            composer.ShowResults();
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
            Console.Write("\n        enter correct mark :  ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
static void VoteInMemoryA()
{
    VoteWindow();
    Composer composer = new ComposerInMemory("Antonio", "Luci", "Vivaldi");
    composer.VoteAdded += ComposerVoteAdded;
    void ComposerVoteAdded(object sender, EventArgs args)
    {
        Console.Write("  Your vote is waiting for approval \n," +
            "\n     add another one :        ");
    }
    Console.SetCursorPosition(0, 5);
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Write("       Write your mark from 1 - 1OO \n" +
                  " also letters from  A - H : \n" +
                  "                              ");
    Console.ForegroundColor = ConsoleColor.White;
    while (true)
    {
        var input = Console.ReadLine();
        if (input == "q")
        {
            Console.WriteLine("\nprogram.VoteInMemoryA() composer.ShowResults();\n" +
                "========================================");
            composer.MemoryFullNameStringBuilder();
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
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{ex.Message}");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n        enter correct mark :  ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

static void VoteInMemoryB() 
{
    VoteWindow();
    var composer = new ComposerInMemory("Johan", "Sebastian", "Bach");
    composer.VoteAdded += ComposerVoteAdded;
    void ComposerVoteAdded(object sender, EventArgs args)
    {
        Console.Write("  Your vote is waiting for approval \n," +
            "\n     add another one :        ");
    }

    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.SetCursorPosition(0, 5);
    Console.Write("       Write your mark from 1 - 1OO \n" +
                  " also letters from  A - H : \n" +
                  "                              ");
    Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.ForegroundColor = ConsoleColor.White;
    while (true)
    {
        var input = Console.ReadLine();
        if (input == "q")
        {
            composer.MemoryFullNameStringBuilder();
            composer.ShowResults();
            break;
        }
        try
        {
            composer.AddGrade(input);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{ex.Message}************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n        enter correct mark :  ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    } 
}

static void Attention(int left, int top, string text)
{
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.SetCursorPosition(left, top);
    Console.WriteLine(text);
}


static void InWhite(int left, int top, string text)
{
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine(text);
}

static void InfoBlue(int left, int top, string text)
{
    Console.BackgroundColor = ConsoleColor.DarkCyan;
    Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(left, top);
    Console.WriteLine(text);
}

static void InfoGray(int left, int top, string text)
{
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.SetCursorPosition(35, top);
    Console.WriteLine(text);
}

static void InGreen(int left,int top, string text)
{
    Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(left, top);
    Console.WriteLine(text);
}

static void Draw(ConsoleColor ColorB, ConsoleColor ColorF, string text)
{
    ColorB = Console.BackgroundColor = ConsoleColor.White;
    ColorF = Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine(text);
}

static void Info()
{
    InfoBlue(45, 1, "   Antonio    Bach    Composers    Info      Menu       Vote      Enter    Exit         "); ;
    InfoBlue(45, 2, "                                                                                        ");
    InfoBlue(45, 3, "      A         B         C         I         M           V        Q        X           ");
}

static void AntonioBachLabel()
{
    InWhite(39, 25, "░░░░░░░░░░░░░░░░░░░░░ A ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ B ░░░░░░░░░░░░░░░░░░░░░░");
    InWhite(39, 26, "░░░░░░░░░{                          }░░░░░░░{                          }░░░░░░░░░");
    InWhite(39, 27, "░░░░░░░░░{   Antonio Luci Vivaldi   }░░░░░░░{   Johan Sebastian Bach   }░░░░░░░░░");
    InWhite(39, 28, "░░░░░░░░░{    ..................    }░░░░░░░{    ..................    }░░░░░░░░░");
}

static void ChooseComposer()
{
    InfoGray(58,20, "                                                          ");
    InfoGray(58,21, "                                                          ");
    InfoGray(58,22, "           C  ENTER          Composer's  Choose           ");
    InfoGray(58,23, "                                                          ");
    InfoGray(58,24, "                                                          ");
    //InGray(25, "                                                          ");
}

static void ComposersList()
{
    InfoGray(35, 34, "                                                                                                 ");
    InfoGray(35, 35, "    Tomaso Albinoni                 Henry Purcell                  Johan Sebastian Bach          ");
    InfoGray(35, 36, "    Gregorio Allegri                                               Georg Friedrich Haendel       ");
    InfoGray(35, 37, "    Arcangelo Corelli               Grzegorz Gerwazy Gorczycki     Johann Pachelbel              ");
    InfoGray(35, 38, "    Benedetto Marcello              Mikołaj Gomółka                Georg Philipp Telemann        ");
    InfoGray(35, 39, "    Claudio Monteverdi              Adam Jarzębski                 Sylvius Leopold Weiss         ");
    InfoGray(35, 40, "    Jacopo Peri                     Marcin Mielczewski                                           ");
    InfoGray(35, 41, "    Antonio Luci Vivaldi            Bartłomiej Pękiel              Jean-Henri d’Anglebert        ");
    InfoGray(35, 42, "    Domenico Scarlatti              Andrzej Rohaczewski            André Campra                  ");
    InfoGray(35, 43, "    Giovanni Battista Sammartini    Sylwester Szarzyński           François Couperin Le Grand    ");
    InfoGray(35, 44, "    Giuseppe Torelli                Mikołaj Zieleński              Marin Marais                  ");
    InfoGray(35, 45, "                                                                   Jean-Philippe Rameau          ");
    InfoGray(35, 46, "                                                                                                 ");
    //InGreen( 97, 34,  composer1.FullName );
    //InGreen(  , 41, " Antonio Luci Vivaldi ");
}



static void Background()
{
    Console.CursorVisible = false;
    Console.BackgroundColor = ConsoleColor.Cyan;
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.SetCursorPosition(0, 0);    
    Console.WriteLine(
      "                                                                                                                                          " +
    "\n                                                                                                                                                      " +
    "\n                                                                                                                                                      " +
    "\n                                                                                                                                                      " +
    "\n                                                                                                                                                      " +
    "\n                                                           ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                                                      " +
    "\n                                                              ^^^^^^^^/   ^^^^^^^^   ^^^^^^^^                                                         " +
    "\n                                        ,,,,,,,,,,,,xxxxxxxxxXXXXX░░xx______~~~~_______xx░░XXXXXxxxxxxxxx,,,,,,,,,,,,                                 " +
    "\n                                 xxxX░░░░░░░░░░░░░░░░░░░░░ ░░░░░░░░░░░░░@░@░░░░░@░@░░░░░░░░░░░░░░░░░░ ░░░░░░░░░░░░░░░░░░░░░░░                         " +
    "\n                        ........o(((░░░░░░░░░░░░░░░░░░░░░░░░░░░░░((                     ))░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░)))o........               " +
    "\n                        ....((░░░░░░░░░░░░░░ ░░░░░░░░░░░░░░░░░░░C___                  ___J░░░░░░░░ ░░░░ ░░ ░░ ░░ ░░░░░░░░░░░)) .......                " +
    "\n                                     ░░░░░░░░░░░░░░░░░░░░░ ░░░░░░░░░░░░xC,       Jx░░░░░░░░░░░ ░░░░░░░░░░░░░░░░░░░░░░░))                              " +
    "\n                                              ^░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░^                                     " +
    "\n  ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░                                                                                                    ░  ░  ░  ░  ░  ░  ░        " +
    "\n       ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░                                                                                                                          " +
    "\n      ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░               W E L C O M E   T O   T H E   S P E A C E   O F  B A R O Q U E   M U S I C        ░  ░  ░  ░  ░  ░  ░       " +
    "\n   ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░                          __________________________________________________________                     ░  ░  ░  ░  ░  ░  ░  " +
    "\n     ░ ^ ^ ^ ^    , , ░░░░░░    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  ░  ░  ░  ░  ░  ░  ░    " +
    "\n              ░ ░ ░ ░                                   ^^^^░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░^^^^                     ░  ░  ░  ░  ░  ░  ░          " +
    "\n                  ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░                                                            ░  ░  ░  ░  ░  ░  ░                          " +
    "\n       ░ ░ ^ ^ ^ ^    , , , , ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░                                                             ░  ░  ░  ░  ░  ░  ░     ░  ░          " +
    "\n       ░  ░ , ░  ░  ░  ░  ░  ░  ░  ░  ░  ░  ░                                                       ░  ░ , ░  ░  ░  ░  ░  ░  ░  ░  ░  ░  ░            " +
    "\n  ░ ░ ░ ░          ░ ░ ░  ░ ░ ░ ░ ░ ░ ░ ░ ░                                                            ░  ░  ░  ░  ░  ░  ░                            " +
    "\n            ░ ░  ░ ░   ░ ░ ░  ░ ░ ░ ░ ░ ░ ░ ░ ░                                                         ░  ░  ░  ░  ░  ░  ░     ░  ░  ░  ░  ░  ░  ░   " +
    "\n      ░ ░ ░ ░       ░ ░ ░ ░ ░ ░ ░ ░ ░ ░ ░                                                                 ░  ░  ░  ░  ░    ░                          " +
    "\n                  ░ ░ ░ ░ ░ ░░ ░ ░ ░ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░    ░  ░  ░  ░  ░  ░         " +
    "\n                                 ░░░░░░░░░░{{*^^^^^^^^^^^^*}}░░░░░░░{{*^^^^^^^^^^^^*}}░░░░░░░{{*^^^^^^^^^^^^*}}░░░░░░░░    ░  ░  ░  ░  ░  ░           " +
    "\n             ░ ░ ░ ░              ░░░░░░░░{{                }}░░░░░{{                }}░░░░░{{                }}░░░░░░      ░  ░  ░  ░  ░  ░  ░       " +
    "\n                             ░░░░░░░░░░░░░{{  ,,,,,,,,,,,,  }}░░░░░{{  ,,,,,,,,,,,,  }}░░░░░{{  ,,,,,,,,,,,,,  }}░░░░░░░░░░░                          " +
    "\n                          ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                       " +
    "\n                                                                                                                                                      " +
    "\n                                                                                                                                                      " +
    "\n                                                                                                                                                      " +
    "\n                                                                                                                                                      " +
    "\n                                                                                                                                                      ");

    //Console.ForegroundColor = ConsoleColor.DarkMagenta;
    //Console.WriteLine(
    //  "                                  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                       " +
    //  "                                                                                                                                                      " +
    //"\n                                          W E L C O M E   T O   T H E   S P E A C E   O F  B A R O Q U E   M U S I C                                  " +
    //"\n                                                    __________________________________________________________                                        " +
    //"\n                                  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                       " +
    //"\n                                                         ^^^^░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░^^^^                                                 " +
    //"\n                                                                                                                                                      " +
    //"\n                                                                                                                                                      " +
    //"\n                                                                                                                                                      " +
    //"\n                                                                                                                                                      " +
    //"\n                                                                                                                                                      " +
    //"\n                              ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░                          " +
    //"\n                                 ░░░░░░░░░░{{*^^^^^^^^^^^^*}}░░░░░░░{{*^^^^^^^^^^^^*}}░░░░░░░{{*^^^^^^^^^^^^*}}░░░░░░░░                               " +
    //"\n                                  ░░░░░░░░{{                }}░░░░░{{                }}░░░░░{{                }}░░░░░░                                " +
    //"\n                             ░░░░░░░░░░░░░{{  ,,,,,,,,,,,,  }}░░░░░{{  ,,,,,,,,,,,,  }}░░░░░{{  ,,,,,,,,,,,,,  }}░░░░░░░░░░░                          ");

    //InfoWhite(25, "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
    //InfoWhite(26, "░░░░░░{{*^^^^^^^^^^^^*}}░░░░░░░{{*^^^^^^^^^^^^*}}░░░░░░░{{*^^^^^^^^^^^^*}}░░░░░░░░");
    //InfoWhite(27, "░░░░░{{                }}░░░░░{{                }}░░░░░{{                }}░░░░░░░░");
    //InfoWhite(28, "░░░░░{{  ,,,,,,,,,,,,  }}░░░░░{{  ,,,,,,,,,,,,  }}░░░░░{{  ,,,,,,,,,,,,,  }}░░░░░░░░");
    //InfoWhite(29, "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
    ChooseComposer();

    InfoBlue(0, 37,
      "    ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░                             Compare music and vote for your favourite classical pices.                           ░░░░░░░░░░░░░░░░░░░░\n" +      
      "    ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░                        Take part in researching the work of the most outstanding composers.                      ░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +       
      "    ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░                                               ________<\">________                                                ░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░                                                                                                                  ░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░                                                                                            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░((((((((                                           ))))))))░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
      "    ░░░░░░░░░░░░░░░░░░░░░░░░                                                                                                    ░░░░░░░░░░░░░░░░░░░░░░░░░░░\n");
}

static void VoteWindow()
{
    InGreen(0, 4,
          "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n                                     ░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░" +
        "\n                                      ");
}

