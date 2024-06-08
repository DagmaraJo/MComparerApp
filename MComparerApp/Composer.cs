using System;

namespace MComparerApp
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

        public string Name { get; private set; }
        //{
        //    get
        //    {
        //        return $"{char.ToUpper(Name[0])}{Name.Substring(1, Name.Length - 1).ToLower()}";
        //    }
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            Name = value;
        //        }
        //    }
        //}

        public string Secondname { get; private set; }
        //{
        //    get
        //    {
        //        return $"{char.ToUpper(Secondname[0])}{Secondname.Substring(1, Secondname.Length - 1).ToLower()}";
        //    }
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(value)) 
        //        {
        //            Secondname = value;
        //        }
        //    }
        //}
        public string Surname { get; private set; }
        //{
        //    get
        //    {
        //        return $"{char.ToUpper(Surname[0])}{Surname.Substring(1, Surname.Length - 1).ToLower()}";
        //    }
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            Surname = value;
        //        }
        //    }
        //}
        public string Age { get; private set; }
        public string Nationality { get; private set; }
        public string Period { get; private set; }
        public string FullName => $"{Name} {Secondname} {Surname}";
        public string FullName2 => $"{Name} {Surname}";

        public abstract void AddGrade(float grade);

        public abstract void AddGrade(string grade);

        public abstract void AddGrade(char grade);

        public abstract void AddGrade(int grade);

        public abstract void AddGrade(double grade);

        public abstract event VoteAddedDelegate NewVoteAdded;

        public abstract Statistics GetStatistics();

        public abstract void MemoryFullNameStringBuilder();

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

        //public virtual event VoteAddedDelegate VoteAdded;

        //protected void CheckEventVoteAdded()
        //{
        //    if (VoteAdded != null)
        //    {
        //        VoteAdded(this, new EventArgs());
        //    }
        //}
    }
}
