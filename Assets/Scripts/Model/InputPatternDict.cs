using System.Collections.Generic;

namespace Model
{
    public static class InputPatternDict
    {
        private static readonly Dictionary<char, List<InputPattern>> Dictionary =
            new()
            {
                {'A', new List<InputPattern> {new("A")}},
                {'B', new List<InputPattern> {new("B")}},
                {'C', new List<InputPattern> {new("C")}},
                {'D', new List<InputPattern> {new("D")}},
                {'E', new List<InputPattern> {new("E")}},
                {'F', new List<InputPattern> {new("F")}},
                {'G', new List<InputPattern> {new("G")}},
                {'H', new List<InputPattern> {new("H")}},
                {'I', new List<InputPattern> {new("I")}},
                {'J', new List<InputPattern> {new("J")}},
                {'K', new List<InputPattern> {new("K")}},
                {'L', new List<InputPattern> {new("L")}},
                {'M', new List<InputPattern> {new("M")}},
                {'N', new List<InputPattern> {new("N")}},
                {'O', new List<InputPattern> {new("O")}},
                {'P', new List<InputPattern> {new("P")}},
                {'Q', new List<InputPattern> {new("Q")}},
                {'R', new List<InputPattern> {new("R")}},
                {'S', new List<InputPattern> {new("S")}},
                {'T', new List<InputPattern> {new("T")}},
                {'U', new List<InputPattern> {new("U")}},
                {'V', new List<InputPattern> {new("V")}},
                {'W', new List<InputPattern> {new("W")}},
                {'X', new List<InputPattern> {new("X")}},
                {'ふ', new List<InputPattern> {new("fu"), new("hu")}}
            };

        public static List<InputPattern> GetInputPattern(char c)
        {
            return Dictionary.GetValueOrDefault(c);
        }
    }
}