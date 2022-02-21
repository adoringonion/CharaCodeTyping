using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Word
    {
        private readonly List<Char> _chars;
        private int _currentCharIndex;

        public Word(string word)
        {
            Value = word;
            _chars = word.ToCharArray().Select(c => new Char(c)).ToList();
        }

        public string Value { get; }
        private Char CurrentChar => _chars[_currentCharIndex];


        public InputResult Input(char c)
        {
            return CurrentChar.Input(c) switch
            {
                Success(var isCompleted) => CheckCompleted(isCompleted),
                Fail => new Fail(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private InputResult CheckCompleted(bool isCompleted)
        {
            if (isCompleted) _currentCharIndex += 1;
            return _chars.Count == _currentCharIndex ? new Success(true) : new Success(false);
        }
    }
}