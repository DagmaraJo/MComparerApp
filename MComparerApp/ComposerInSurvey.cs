namespace MComparerApp
{
    internal class ComposerInSurvey : Composer
    {
        public ComposerInSurvey(string name, string secondname, string surname)
            : base(name, secondname, surname)
        {
            fullFileName = $"{name}{secondname}{surname}{fileName}";
        }

        private const string fileName = "_grades.txt";
        readonly string fullFileName;

        public override event VoteAddedDelegate NewVoteAdded;

        //List<float> list1 = new List<float>();
        //List<float> list2 = new List<float>();

        //public override void AddGrade(float grade)
        //{
        //    if (grade >= 0.002 && grade <= 100.009)
        //    {
        //        switch (grade)
        //        {
        //            case 4.0f:
        //                list1.Add(grade);
        //                break;

        //            case 3.5f:
        //                list2.Add(grade);
        //                break;

        //            default:
        //                // Obsłuż inne oceny, jeśli potrzeba
        //                break;
        //        }
        //    }
        //}


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
            if (grade.Contains('+') || grade.Contains('-'))
            {
                switch (grade)
                {
                    case "S+": case "s+": AddGrade(100.009); break;

                    case "T+": case "t+": AddGrade(100.008); break;

                    case "U+": case "u+": AddGrade(100.007); break;

                    case "V+": case "v+": AddGrade(100.006); break;

                    case "W-": case "w-": AddGrade(0.005); break;

                    case "X-": case "x-": AddGrade(0.004); break;

                    case "Y-": case "y-": AddGrade(0.003); break;

                    case "Z-": case "z-": AddGrade(0.002); break;

                    case "S-": case "s-": AddGrade(0.009); break;

                    case "T-": case "t-": AddGrade(0.008); break;

                    case "U-": case "u-": AddGrade(0.007); break;

                    case "V-": case "v-": AddGrade(0.006); break;

                    case "W+": case "w+": AddGrade(100.005); break;

                    case "X+": case "x+": AddGrade(100.004); break;

                    case "Y+": case "y+": AddGrade(100.003); break;

                    case "Z+": case "z+": AddGrade(100.002); break;

                    default:
                        throw new ArgumentException($"Only letters S - Z with + or - are allowed!");
                }
            }
            else
            {
                if (float.TryParse(grade, out float result))
                {
                    this.AddGrade(result);
                }
                else if (char.TryParse(grade, out char cResult))
                {
                    this.AddGrade(cResult);
                }
                else
                {
                    throw new Exception("      String is not float !   ▀▀▀▀▀");
                }
            }
        }

        public new void AddGrade(char grade)
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
                    throw new Exception("  Wrong Letter ! use A - H \n" +
                        " Survey sign are akcept only with + or -");
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
