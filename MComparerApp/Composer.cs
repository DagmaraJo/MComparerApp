﻿namespace MComparerApp
{
    public delegate void VoteAddedDelegate(object sender, EventArgs args);

    public abstract class Composer : IComposer
    {
        public Composer()
        {
        }

        public Composer(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public Composer(string name, string secondname, string surname)
        {
            this.Name = name;
            this.Secondname = secondname;
            this.Surname = surname;
        }

        public Composer(string name, string secondname, string surname, string Age)
        {
            this.Name = name;
            this.Secondname = secondname;
            this.Surname = surname;
            this.Age = Age;
        }

        public string? Name { get; private set; }
        

        public string? Secondname { get; private set; }
        
        public string? Surname { get; private set; }
        
        public string? Age { get; private set; }

        public string? Nationality { get; private set; }
        
        public string? Period { get; private set; }
        
        public string FullName => $"{Name} {Secondname} {Surname}";
        
        public string? FullName2 => $"{Name} {Surname}";

        public abstract void AddGrade(float grade);

        public abstract void AddGrade(string grade);

        public void AddGrade(char grade)
        {
            switch (char.ToUpper(grade))
            {
                case 'A':
                    this.AddGrade(100);
                    break;
                case 'B':
                    this.AddGrade(90);
                    break;
                case 'C':
                    this.AddGrade(80);
                    break;
                case 'D':
                    this.AddGrade(70);
                    break;
                case 'E':
                    this.AddGrade(60);
                    break;
                case 'F':
                    this.AddGrade(50);
                    break;
                case 'G':
                    this.AddGrade(30);
                    break;
                case 'H':
                    this.AddGrade(10);
                    break;
                default:
                    throw new Exception("             Wrong Letter !   ▀▀▀▀▀");
            }
        }

        public void AddGrade(int grade)
        {
            float gradeAsInt = grade;
            this.AddGrade(gradeAsInt);
        }

        public void AddGrade(double grade)
        {
            float gradeAsDouble = (float)grade;
            this.AddGrade(gradeAsDouble);
        }

        public abstract event VoteAddedDelegate NewVoteAdded;

        public abstract Statistics GetStatistics();

        public void ShowResults()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n     *    R E S U L T S    *    ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                                ");
            Console.WriteLine($"    {this.FullName.ToUpper()}  * *   ");
            Console.WriteLine("                                ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" ****************************** ");
            Console.WriteLine($"    Total votes :  {GetStatistics().Count}           ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"    Total marks :  {GetStatistics().Sum:N0}        ");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"        Average :  {GetStatistics().Average:N0}          ");
            Console.WriteLine($"            Max :  {GetStatistics().Max:N0}         ");
            Console.WriteLine($"            Min :  {GetStatistics().Min:N0}           ");
            Console.WriteLine(" ------------------------------");
            Console.Write("XXXShowResults();/from baseXXXX");
        }
    }
}
