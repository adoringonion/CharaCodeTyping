using Model;
using NUnit.Framework;

namespace Editor.Tests
{
    public class CharTests
    {
        [Test]
        public void FirstInput_True_Test()
        {
            var c = new Char('A');
            Assert.AreEqual(new Success(true), c.Input(new Key('A')));
        }

        [Test]
        public void FirstInput_False_Test()
        {
            var c = new Char('A');
            Assert.AreEqual(new Fail(), c.Input(new Key('B')));
        }

        [Test]
        public void JP_FirstInput_True_test()
        {
            var c = new Char('ふ');
            Assert.AreEqual(new Success(false), c.Input(new Key('h')));
        }

        [Test]
        public void JP_InputComplete_True_test()
        {
            var c = new Char('ふ');
            Assert.AreEqual(new Success(false), c.Input(new Key('f')));
            Assert.AreEqual(new Success(true), c.Input(new Key('u')));
        }
    }
}