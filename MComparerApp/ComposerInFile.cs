namespace MComparerApp
{
    internal class ComposerInFile : Composer
    {
        private const string fileName = "_grades.txt";
        readonly string fullFileName;

        public override event VoteAddedDelegate NewVoteAdded;

        public ComposerInFile()
            : base() { }

        public ComposerInFile(string name, string surname)
            : base(name, surname)
        {
            fullFileName = $"{name}{surname}{fileName}";
        }

        public ComposerInFile(string name, string secondname, string surname) 
            : base(name, secondname, surname)
        {
            fullFileName = $"{name}{secondname}{surname}{fileName}";
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0.002 && grade <= 100.009)
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine(grade);
                    NewVoteAdded?.Invoke(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("      Invalid grade value !   ▀▀▀▀▀");
            }
        }

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else if (char.TryParse(grade, out char chResult))
            {
                this.AddGrade(chResult);
            }
            else
            {
                throw new Exception("      String is not float !   ▀▀▀▀▀");
            }
        }

        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = CountStatistics(gradesFromFile);
            return result;
        }

        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists($"{fullFileName}"))
            {
                using (var reader = File.OpenText($"{fullFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }

        private static Statistics CountStatistics(List<float> grades)
        {
            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
