using System.Collections.Generic;
using CharaCodeTyping.Scripts.Model;
using UnityEngine;

namespace CharaCodeTyping.Scripts.Service
{
    public class RandomWord
    {
        private readonly List<string> _wordList = new()
        {
            "TEST",
            "APPLE",
            "BALL"
        };

        public Word NextWord()
        {
            var randomWord = SelectRandomWord();
            return new Word(randomWord);
        }

        private string SelectRandomWord()
        {
            return _wordList[Random.Range(0, _wordList.Count - 1)];
        }
    }
}