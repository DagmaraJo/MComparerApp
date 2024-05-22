using System;
using System.Collections.Generic;
using static MComparerApp.Composer;

namespace MComparerApp
{
    public interface IComposer
    {
        string Name { get; }
        string Secondname { get; }
        string Surname { get; }
        string Age { get; }
        string Nationality { get; }
        string Period { get; }
        void AddGrade(float grade);
        void AddGrade(string grade);
        void AddGrade(char grade);
        void AddGrade(int grade);
        void AddGrade(double grade);

        //event VoteAddedDelegate VoteAdded;
        //event VoteMaxDelegate VoteMax;
        //event VoteMinDelegate VoteMin;

        Statistics GetStatistics();
        //Statistics CountMax();
        //Statistics CountMin();
    }
}
