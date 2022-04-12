using System.Collections.Generic;
using UnityEngine;

namespace CharaCodeTyping.Scripts.Model
{
    public class RandomWord
    {
        private readonly List<string> _wordList = new()
        {
            "",
            "Apple",
            "Ball"
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