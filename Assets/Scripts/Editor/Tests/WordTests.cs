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
            Assert.AreEqual(new Success(false), word.Input('T'));
        }

        [Test]
        public void FirstInput_False()
        {
            var word = new Word("TEST");
            Assert.AreEqual(new Fail(), word.Input('B'));
        }

        [Test]
        public void SecondInput_True()
        {
            var word = new Word("TEST");
            word.Input('T');
            Assert.AreEqual(new Success(false), word.Input('E'));
        }

        [Test]
        public void InputComplete_True()
        {
            var word = new Word("TEST");
            word.Input('T');
            word.Input('E');
            word.Input('S');
            Assert.AreEqual(new Success(true), word.Input('T'));
        }
    }
}