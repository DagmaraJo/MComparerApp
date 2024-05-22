using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComparerApp
{
    public class ComposerInMemory : Composer
    {
        public List<float> grades = new List<float>();
        private readonly List<float> ComposerVote = new List<float>();
        public override event VoteAddedDelegate VoteAdded;
        private readonly List<float> ComposerVoteMax = new List<float>();
        public override event VoteMaxDelegate VoteMax;
        private readonly List<float> ComposerVoteMin = new List<float>();
        public override event VoteMinDelegate VoteMin;

        public ComposerInMemory(string name, string surname)
            : base(name, surname) { }

        public ComposerInMemory(string name, string secondname, string surname)
            : base(name, secondname, surname) { }

        public ComposerInMemory(string name, string secondname, string surname, string age)
            : base(name, secondname, surname, age) { }

        public override void AddGrade(float grade)
        {
            if (grade >=0 && grade <= 100)
            {
                this.ComposerVote.Add(grade);
                //CheckEventVoteAdded();
                if (VoteAdded != null)
                {
                    VoteAdded(this, new EventArgs());
                }
            }
            //else if (grade == 100)
            //{
            //    this.ComposerVoteMax.Add(grade);
            //    //CheckEventVoteMax();
            //    if (VoteMax != null)
            //    {
            //        VoteMax(this, new EventArgs());
            //    }
            //}
            //else if (grade == 0)
            //{
            //    this.ComposerVoteMin.Add(grade);
            //    if (VoteMin != null)
            //    {
            //        VoteMin(this, new EventArgs());
            //    }
            //}
            else
            {
                throw new Exception("      Invalid grade value !");
            }
        }

        public float Result
        {
            get
            {
                return this.ComposerVote.Sum();
            }
        }

        //public float MinCount
        //{
        //    get
        //    {
        //        return ComposerVoteMin.Count;
        //    }
        //}

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
                    this.AddGrade(80);
                    break;
                case 'C':
                    this.AddGrade(60);
                    break;
                case 'D':
                    this.AddGrade(40);
                    break;
                case 'E':
                    this.AddGrade(20);
                    break;
                case 'F':
                    this.AddGrade(10);
                    break;
                case 'G':
                    this.AddGrade(3.14f);
                    break;
                case 'H':
                    this.AddGrade(0);
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
            var statistics = new Statistics();

            foreach (var grade in this.ComposerVote) // List<float> grades ? or this.ComposerVote
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }

        public override void MemoryFullNameStringBuilder()
        {
            Console.WriteLine("\n=========>> in MemoryFullNameStringBuilder(); ");
            StringBuilder sb = new StringBuilder($"    {this.FullName.ToUpper()}    * * * ");
            for (int i = 0; i < grades.Count; i++)
            {
                if (i == grades.Count )
                    sb.Append($"{grades[i]}");
                else
                    sb.Append($"{grades[i]}");
            }
            Console.WriteLine(sb);
        }
    }
}
