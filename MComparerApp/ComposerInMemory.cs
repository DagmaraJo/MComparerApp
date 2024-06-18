namespace MComparerApp
{
    public class ComposerInMemory : Composer
    {
        public List<float> grades = new();

        public override event VoteAddedDelegate NewVoteAdded;

        public ComposerInMemory()
            : base() { }

        public ComposerInMemory(string name, string surname)
            : base(name, surname) { }

        public ComposerInMemory(string name, string secondname, string surname)
            : base(name, secondname, surname) { }

        public ComposerInMemory(string name, string secondname, string surname, string age)
            : base(name, secondname, surname, age) { }

        public override void AddGrade(float grade)
        {
            if (grade >=1 && grade <= 100)
            {
                this.grades.Add(grade);
                NewVoteAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new Exception("      Invalid grade value !   ▀▀▀▀▀");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
