using Model;
using NUnit.Framework;

namespace Editor.Tests
{
    public class WordTests
    {
        [Test]
        public void FirstInput_True()
        {
            var word = new Word("TEST");
            Assert.AreEqual(new Success(false), word.Input(new Key('T')));
        }

        [Test]
        public void FirstInput_False()
        {
            var word = new Word("TEST");
            Assert.AreEqual(new Fail(), word.Input(new Key('B')));
        }

        [Test]
        public void SecondInput_True()
        {
            var word = new Word("TEST");
            word.Input(new Key('T'));
            Assert.AreEqual(new Success(false), word.Input(new Key('E')));
        }

        [Test]
        public void InputComplete_True()
        {
            var word = new Word("TEST");
            word.Input(new Key('T'));
            word.Input(new Key('E'));
            word.Input(new Key('S'));
            Assert.AreEqual(new Success(true), word.Input(new Key('T')));
        }

        [Test]
        public void InputComplete_False()
        {
            var word = new Word("TEST");
            word.Input(new Key('T'));
            word.Input(new Key('E'));
            word.Input(new Key('S'));
            Assert.AreEqual(new Fail(), word.Input(new Key('S')));
        }
    }
}