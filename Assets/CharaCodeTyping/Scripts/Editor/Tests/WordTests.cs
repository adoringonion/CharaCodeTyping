using CharaCodeTyping.Scripts.Model;
using NUnit.Framework;

namespace CharaCodeTyping.Scripts.Editor.Tests
{
    public class WordTests
    {
        [Test]
        public void FirstInput_True()
        {
            var word = new Word("TEST");
            Assert.AreEqual(InputResult.Success, word.Input(new Key('T')));
        }

        [Test]
        public void FirstInput_False()
        {
            var word = new Word("TEST");
            Assert.AreEqual(InputResult.Fail, word.Input(new Key('B')));
        }

        [Test]
        public void SecondInput_True()
        {
            var word = new Word("TEST");
            word.Input(new Key('T'));
            Assert.AreEqual(InputResult.Success, word.Input(new Key('E')));
        }

        [Test]
        public void InputComplete_True()
        {
            var word = new Word("TEST");
            word.Input(new Key('T'));
            word.Input(new Key('E'));
            word.Input(new Key('S'));
            Assert.AreEqual(InputResult.Complete, word.Input(new Key('T')));
        }

        [Test]
        public void InputComplete_False()
        {
            var word = new Word("TEST");
            word.Input(new Key('T'));
            word.Input(new Key('E'));
            word.Input(new Key('S'));
            Assert.AreEqual(InputResult.Fail, word.Input(new Key('S')));
        }
    }
}