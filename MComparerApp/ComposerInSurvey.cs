using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComparerApp
{
    internal class ComposerInSurvey : ComposerInFile
    {
        //private readonly List<float> ComposerVoteList = new List<float>();

        public ComposerInSurvey(string name, string secondname, string surname)
            : base(name, secondname, surname)
        {
        }

        public override event VoteAddedDelegate NewVoteAdded;

        //private const string fileName = "_vote.txt";
        //readonly string fullFileName;

        //public ComposerInSurvey(string name, string secondname, string surname) : base(name, secondname, surname)
        //{
        //    fullFileName = $"{name}_{secondname}_{surname}{fileName}";
        //}

        //public override void AddGrade(float grade)
        //{
        //    if (grade >= 0 && grade <= 100)
        //    {
        //        using (var writer = File.AppendText(fullFileName))
        //        {
        //            writer.WriteLine(grade);
        //            if (NewVoteAdded != null)
        //            {
        //                NewVoteAdded(this, new EventArgs());
        //            }
        //            //CheckEventVoteAdded();
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("      Invalid grade value !");
        //    }
        //}

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
                    throw new Exception("      String is not float !");
                }
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
                    throw new Exception("  Wrong Letter ! use A - H \n" +
                        " Survey sign are akcept only with + or -");
            }
        }
    }
}
