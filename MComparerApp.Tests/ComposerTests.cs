using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MComparerApp.Tests
{
    internal class ComposerTests
    {
        [Test]
        public void WhenComposerCollectFiveGrades_ShouldReturnCorrectSum()
        {
            var composer = new ComposerInMemory("Alessandro", "Marcello");
            composer.AddGrade(100);
            composer.AddGrade(7);
            composer.AddGrade(1);
            composer.AddGrade(2);
            composer.AddGrade(2);

            var result = composer.Result;

            Assert.AreEqual(112, result);
        }

        [Test]
        public void WhenComposerCollectFourGrades_ShouldReturnCorrectAverage()
        {
            var composer = new ComposerInMemory("Alessandro", "Marcello");
            composer.AddGrade(100);
            composer.AddGrade(90);
            composer.AddGrade(60);
            composer.AddGrade(70);

            var statistics = composer.GetStatistics();

            Assert.AreEqual(80, statistics.Average);
        }

        [Test]
        public void WhenComposerCollectGrades_ShouldReturnCorrectStatistics()
        {
            var composer = new ComposerInMemory("Alessandro", "Marcello");
            composer.AddGrade(100);
            composer.AddGrade(90);
            composer.AddGrade(60);
            composer.AddGrade(70);

            var result = composer.GetStatistics();

            Assert.AreEqual(80, result.Average, 1);
            Assert.AreEqual(100, result.Max, 1);
            Assert.AreEqual(60, result.Min, 1);
            Assert.AreEqual(4, result.Count, 1);
            Assert.AreEqual(320, result.Sum, 1);
        }




        //[Test]
        //public void WhenComposerGetMaxGrade_CheckCorrectTotalMax()
        //{
        //    // arrange
        //    var composer = new ComposerInMemory("Alessandro", "Marcello");
        //    composer.AddGrade(100);
        //    composer.AddGrade(0);
        //    composer.AddGrade(0);
        //    composer.AddGrade(0);
        //    composer.AddGrade(70);

        //    // act
        //    var result = composer.MinCount;

        //    // assert
        //    Assert.AreEqual(100, result);
        //}



        //[Test]
        //public void WhenComposerGetMinGrade_CountMinGrades()
        //{
        //    var composer = new ComposerInMemory("Alessandro", "Marcello");
        //    composer.AddGrade(100);
        //    composer.AddGrade(100);
        //    composer.AddGrade(13);
        //    composer.AddGrade(80);
        //    composer.AddGrade(100);

        //    var result = composer.MaxCount;

        //    Assert.AreEqual(3, result);
        //}
    }
}

