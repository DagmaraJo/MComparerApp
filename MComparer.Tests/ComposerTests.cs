namespace MComparerApp.Tests
{
    internal class ComposerTests
    {
        [Test]
        public void WhenComposerCollectFourGrades_ShouldReturnCorrectAverage()
        {
            var composer = new ComposerInMemory("Tomaso", "Albinoni");
            composer.AddGrade(100);
            composer.AddGrade(90);
            composer.AddGrade(60);
            composer.AddGrade(70);

            var statistics = composer.GetStatistics();

            Assert.That(statistics.Average, Is.EqualTo(80));
        }

        [Test]
        public void WhenComposerCollectGrades_ShouldReturnCorrectStatistics()
        {
            var composer = new ComposerInMemory("Tomaso", "Albinoni");
            composer.AddGrade(100);
            composer.AddGrade(90);
            composer.AddGrade(60);
            composer.AddGrade(70);

            var result = composer.GetStatistics();

            Assert.That(result.Average, Is.EqualTo(80).Within(1));
            Assert.That(result.Max, Is.EqualTo(100).Within(1));
            Assert.That(result.Min, Is.EqualTo(60).Within(1));
            Assert.That(result.Count, Is.EqualTo(4).Within(1));
            Assert.That(result.Sum, Is.EqualTo(320).Within(1));
        }
    }
}
