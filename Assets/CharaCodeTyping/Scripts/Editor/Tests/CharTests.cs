using CharaCodeTyping.Scripts.Model;
using NUnit.Framework;

namespace CharaCodeTyping.Scripts.Editor.Tests
{
    public class CharTests
    {
        [Test]
        public void FirstInput_True_Test()
        {
            var c = new Char('A');
            Assert.AreEqual(InputResult.Complete, c.Input(new Key('A')));
        }

        [Test]
        public void FirstInput_False_Test()
        {
            var c = new Char('A');
            Assert.AreEqual(InputResult.Fail, c.Input(new Key('B')));
        }

        [Test]
        public void JP_FirstInput_True_test()
        {
            var c = new Char('ふ');
            Assert.AreEqual(InputResult.Success, c.Input(new Key('h')));
        }

        [Test]
        public void JP_InputComplete_True_test()
        {
            var c = new Char('ふ');
            Assert.AreEqual(InputResult.Success, c.Input(new Key('f')));
            Assert.AreEqual(InputResult.Complete, c.Input(new Key('u')));
        }
    }
}