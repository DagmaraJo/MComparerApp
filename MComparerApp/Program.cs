using MComparerApp;

bool Exit = false;
while (!Exit)
{
    WriteLineInformation();
    string name, secondname, surname;
    ConsoleKeyInfo key = Console.ReadKey();
    switch (key.Key)
    {
        case ConsoleKey.M:
            InsertFullName(out name, out secondname, out surname);
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(secondname) && !string.IsNullOrEmpty(surname))
            {
                var composer = new ComposerInMemory(name, secondname, surname);
                composer.NewVoteAdded += NewVoteToMemory;
                TryCatchVote(composer);
                WriteAttention("\n     Remember, this vote will not be saved !     ");
            }
            else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                var composer = new ComposerInMemory(name, surname);
                composer.NewVoteAdded += NewVoteToMemory;
                TryCatchVote(composer);
                WriteAttention("\n     Remember, this vote will not be saved !     ");
            }
            else
            {
                WriteAttention("\n\n\n    The name and the surname can not be empty!   ");
            }
            break;
        case ConsoleKey.F:
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
                WriteAttention("\n\n\n    The name and the surname can not be empty!   ");
            }
            break;
        case ConsoleKey.Escape:
            Exit = true;
            Environment.Exit(0); break;
        default:
            Console.Clear();
            WriteAttention("\n\n\n      Invalid operation.    ");
            break;
    }
}



static void NewVoteToMemory(object sender, EventArgs args)
{
    Console.Write(" Vote is waiting for approval\n");
    Console.Write("       add another one :       ");
}

static void NewVoteToFile(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write("        Your vote is saved \n");
    Console.ResetColor();
    Console.Write("       add another one :       ");
}

static void TryCatchVote(Composer composer)
{
    Console.Write("\n\n\n    Write your mark from 1 - 1OO, also letters from A - H."+
     "\n    When you finish enter q to view the statistics :");
    Console.Write("\n                               ");
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
            Console.ResetColor();
            Console.Write("\n      enter correct mark :     ");
        }
    }
}

static void InsertFullName(out string name, out string secondname, out string surname)
{
    Console.Clear();
    Console.Write("\n\n   Please insert composer's first name   :  ");
    name = Console.ReadLine();
    Console.Write("\n\n   Please insert composer's second name  :  ");
    secondname = Console.ReadLine();
    Console.Write("\n\n   Please insert composer's last name    :  ");
    surname = Console.ReadLine();
}

static void WriteLineInformation()
{
    Console.Clear();
    Console.WriteLine("\n\n\n" +
        "             W E L C O M E   T O   T H E   M U S I C   C O M P A R E R " +
        "\n\n\n                Compare music and vote for your favourite composer." +
        "\n\n                                ________<\">________ " +
        "\n\n\n\n\n    Enter F   if you want to save your vote in text file " +
        "\n\n    Enter M   if you don't want to to save your vote.");
}

static void WriteAttention(string text)
{
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(text);
    Console.ResetColor();
    Console.ReadKey();
}

