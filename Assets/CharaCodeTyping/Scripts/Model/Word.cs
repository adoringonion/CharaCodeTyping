using System;
using System.Collections.Generic;
using System.Linq;

namespace CharaCodeTyping.Scripts.Model
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

        private bool IsCompleted => _chars.Count == _currentCharIndex;


        public InputResult Input(Key key)
        {
            switch (CurrentChar.Input(key))
            {
                case InputResult.Success:
                    return InputResult.Success;
                case InputResult.Complete:
                    _currentCharIndex += 1;
                    return IsCompleted ? InputResult.Complete : InputResult.Success;
                case InputResult.Fail:
                    return InputResult.Fail;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}