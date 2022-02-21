using Model;
using NUnit.Framework;

namespace Editor.Tests
{
    public class InputPatternTests
    {
        [Test]
        public void NewTestScriptSimplePasses()
        {
            var inputPattern = new InputPattern("A");
            Assert.True(inputPattern.FirstChar('A'));
        }

        [Test]
        public void CharIndexAdvanceTest()
        {
            var inputPattern = new InputPattern("ABC");
            Assert.True(inputPattern.FirstChar('A'));
            inputPattern.AdvancePatternCharIndex();
            Assert.True(inputPattern.IsValidCurrentChar('B'));
            inputPattern.AdvancePatternCharIndex();
            Assert.True(inputPattern.IsValidCurrentChar('C'));
        }
    }
}
