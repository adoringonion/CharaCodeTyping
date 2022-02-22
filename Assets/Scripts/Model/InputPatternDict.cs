using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public static class InputPatternDict
    {
        private static readonly Dictionary<char, string[]> Dictionary = new()
        {
            {'A', new[] {"A"}},
            {'B', new[] {"B"}},
            {'C', new[] {"C"}},
            {'D', new[] {"D"}},
            {'E', new[] {"E"}},
            {'F', new[] {"F"}},
            {'G', new[] {"G"}},
            {'H', new[] {"H"}},
            {'I', new[] {"I"}},
            {'J', new[] {"J"}},
            {'K', new[] {"K"}},
            {'L', new[] {"L"}},
            {'M', new[] {"M"}},
            {'N', new[] {"N"}},
            {'O', new[] {"O"}},
            {'P', new[] {"P"}},
            {'Q', new[] {"Q"}},
            {'R', new[] {"R"}},
            {'S', new[] {"S"}},
            {'T', new[] {"T"}},
            {'U', new[] {"U"}},
            {'V', new[] {"V"}},
            {'W', new[] {"W"}},
            {'X', new[] {"X"}},
            {'ふ', new[] {"fu", "hu"}}
        };

        public static InputPattern[] GetInputPattern(char c)
        {
            return Dictionary.GetValueOrDefault(c).Select(x => new InputPattern(x)).ToArray();
        }
    }
}