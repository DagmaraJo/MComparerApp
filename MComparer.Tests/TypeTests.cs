namespace MComparerApp.Tests
{
    public class TypeTests
    {
        [Test]
        public void Test()
        {
            int number1 = 1;
            int number2 = 1;

            Assert.That(number1, Is.EqualTo(number2));
        }

        [Test]
        public void Test2()
        {
            string number1 = ("Antonio");
            string number2 = ("Antonio");

            Assert.That(number1, Is.EqualTo(number2));
        }

        [Test]
        public void Test3()
        {
            var composer1 = ("Antonio");
            var composer2 = ("Antonio");

            Assert.That(composer1, Is.EqualTo(composer2));
        }

        [Test]
        public void GetComposerShouldReturnDifferentObjects()
        {
            var composer1 = GetComposer("Henry", "Purcell");
            var composer2 = GetComposer("Henry", "Purcell");

            Assert.That(composer1, Is.Not.EqualTo(composer2));
        }

        [Test]
        public void GetComposerShouldReturnTheSameFullName()
        {
            var composer1 = GetComposer("Henry", "Purcell");
            var composer2 = GetComposer("Henry", "Purcell");

            Assert.That(composer1.FullName2, Is.EqualTo(composer2.FullName2));
        }

        private Composer GetComposer(string name, string surname)
        {
            return new ComposerInMemory(name, surname);
        }
    }
}
