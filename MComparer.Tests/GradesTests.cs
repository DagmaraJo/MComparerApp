namespace MComparerApp.Tests
{
    public class GradesTests
    {
        [Test]
        public void Test1()
        {
            int grade1 = 6;
            int grade2 = 15;
            int grade3 = 34;

            int result = grade1 + grade2 + grade3;

            Assert.That(result, Is.EqualTo(55));
        }

        [Test]
        public void Test2()
        {
            float grade1 = 10;
            float grade2 = 40;

            float result = (grade1 + grade2) / 2;

            Assert.That(result, Is.EqualTo(25));
        }

        [Test]
        public void Test3()
        {
            float grade1 = 6;
            float grade2 = 6;
            float grade3 = 6;

            float result = grade1 + grade2 + grade3;

            Assert.That(result, Is.EqualTo(18));
        }


        [Test]
        public void WhenGradesAreTheSame_ShouldReturnCorect()
        {
            float grade1 = 6;
            float grade2 = 6;
            float grade3 = 6;

            float result = grade1 + grade2 + grade3;

            Assert.That(result, Is.EqualTo(18));
        }

        [Test]
        public void WhenAddedTwoGrades_SholdReturnAverage()
        {
            float grade1 = 12;
            float grade2 = 36;

            var average = (grade1 + grade2) / 2;

            Assert.That(average, Is.EqualTo(24));
        }
    }
}