using System;

namespace MComparerApp
{
    public delegate void VoteAddedDelegate(object sender, EventArgs args);
    public delegate void VoteMaxDelegate(object sender, EventArgs args);
    public delegate void VoteMinDelegate(object sender, EventArgs args);

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
        public string Secondname { get; private set; }
        public string Surname { get; private set; }
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

        public abstract Statistics GetStatistics();

        //public abstract Statistics CountMax();

        //public abstract Statistics CountMin();

        public abstract event VoteAddedDelegate VoteAdded;

        public abstract event VoteMaxDelegate VoteMax;

        public abstract event VoteMinDelegate VoteMin;

        public abstract void MemoryFullNameStringBuilder();

        public void ShowResults()
        {
            Console.WriteLine(" ShowResults(); << from base XXXXXXXXXXXXXXX");
            Console.WriteLine(" ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine($"  {this.FullName.ToUpper()}  ");
            Console.WriteLine(" ________________________________________");
            Console.WriteLine("XXXXXXXXXXXXXXXXX<<  R E S U L T S  >>XXXXX");
            Console.WriteLine($"    Total votes :  {GetStatistics().Count}");
            Console.WriteLine($"    Total marks :  {GetStatistics().Sum:N2} ");
            Console.WriteLine($"        Average :  {GetStatistics().Average:N2}");
            Console.WriteLine($"            Max :  {GetStatistics().Max:N2} ");
            Console.WriteLine($"            Min :  {GetStatistics().Min:N2}");
            Console.WriteLine("-------------------------------------------");

        //    Console.WriteLine($"   {GetStatistics().Count}    {this.FullName.ToUpper()}");
        //    Console.WriteLine(" _______Total VOTES ________________________");
        //    Console.WriteLine("XXXXXXXXXXXXXXXXX<<  R E S U L T S  >>XXXXX");
        //    Console.WriteLine($"  Max :  {GetStatistics().Max:N2}               Min :  {GetStatistics().Min:N2}");
        }

        //public virtual event VoteAddedDelegate VoteAdded;

        //public virtual event VoteMaxDelegate VoteMax;

        //protected void CheckEventVoteAdded()
        //{
        //    if (VoteAdded != null)
        //    {
        //        VoteAdded(this, new EventArgs());
        //    }
        //}

        //protected void CheckEventVoteMax()
        //{
        //    if (VoteMax != null)
        //    {
        //        VoteMax(this, new EventArgs());
        //    }
        //}
    }
}
