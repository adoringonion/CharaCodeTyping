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
            {'Y', new[] {"Y"}},
            {'Z', new[] {"Z"}},
            {'a', new[] {"a"}},
            {'b', new[] {"b"}},
            {'c', new[] {"c"}},
            {'d', new[] {"d"}},
            {'e', new[] {"e"}},
            {'f', new[] {"f"}},
            {'g', new[] {"g"}},
            {'h', new[] {"h"}},
            {'i', new[] {"i"}},
            {'j', new[] {"j"}},
            {'k', new[] {"k"}},
            {'l', new[] {"l"}},
            {'m', new[] {"m"}},
            {'n', new[] {"n"}},
            {'o', new[] {"o"}},
            {'p', new[] {"p"}},
            {'q', new[] {"q"}},
            {'r', new[] {"r"}},
            {'s', new[] {"s"}},
            {'t', new[] {"t"}},
            {'u', new[] {"u"}},
            {'v', new[] {"v"}},
            {'w', new[] {"w"}},
            {'x', new[] {"x"}},
            {'y', new[] {"y"}},
            {'z', new[] {"z"}},
            {'ふ', new[] {"fu", "hu"}}
        };

        public static InputPattern[] GetInputPattern(char c)
        {
            return Dictionary.GetValueOrDefault(c).Select(x => new InputPattern(x)).ToArray();
        }
    }
}