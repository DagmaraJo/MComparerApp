using MComparerApp;
using System;
using System.Text;

namespace MComparerApp
{
    internal class ComposerInFile : Composer
    {
        private const string fileName = "_grades.txt";
        readonly string fullFileName;

        public override event VoteAddedDelegate NewVoteAdded;

        //public override event VoteMaxDelegate VoteMax;

        //public override event VoteMinDelegate VoteMin;

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

        //public override void MemoryFullNameStringBuilder()
        //{
        //    Console.WriteLine("\n=========>> in MemoryFullNameStringBuilder(); ");
        //    StringBuilder sb = new StringBuilder($"    {this.FullName.ToUpper()}    * * * ");
        //    for (int i = 0; i < grades.Count; i++)
        //    {
        //        if (i == grades.Count)
        //            sb.Append($"{grades[i]}");
        //        else
        //            sb.Append($"{grades[i]}");
        //    }
        //    Console.WriteLine(sb);
        //}

        public override void AddGrade(float grade)
        {
            if (grade >= 0.002 && grade <= 100.009)
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine(grade);
                    //CheckEventVoteAdded();
                    if (NewVoteAdded != null)
                    {
                        NewVoteAdded(this, new EventArgs());
                    }
                }
            }
            //else if (grade == 100)
            //{
            //    using (var writer = File.AppendText(fullFileName))
            //    {
            //        writer.WriteLine(grade);
            //        //CheckEventVoteMax();
            //    }
            //    //if (VoteMax != null)
            //    //{
            //    //    VoteMax(this, new EventArgs());
            //    //}
            //}
            //else if (grade == 0)
            //{
            //    using (var writer = File.AppendText(fullFileName))
            //    {
            //        writer.WriteLine(grade);
            //    }
            //    //if (VoteMin != null)
            //    //{
            //    //    VoteMin(this, new EventArgs());
            //    //}
            //}
            else
            {
                throw new Exception("      Invalid grade value !");
            }
        }

        public override void AddGrade(string grade)
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
                throw new Exception("      String is not float !");
            }
        }

        public override void AddGrade(char grade)
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
                    throw new Exception("      Wrong Letter !");
            }
        }

        public override void AddGrade(int grade)
        {
            float gradeAsInt = grade;
            this.AddGrade(gradeAsInt);
        }

        public override void AddGrade(double grade)
        {
            float gradeAsDouble = (float)grade;
            this.AddGrade(gradeAsDouble);
        }

        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
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

        private Statistics CountStatistics(List<float> grades)
        {
            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }

        public override void MemoryFullNameStringBuilder()
        {
            throw new NotImplementedException();
        }
    }

}
