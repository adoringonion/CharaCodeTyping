using System.Collections.Generic;
using Model;
using UnityEngine;

namespace Service
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