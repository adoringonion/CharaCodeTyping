using System.Collections.Generic;

namespace Model
{
    public class InputPatterns
    {
        private readonly List<InputPattern> _value;
        private int _selectedPatternIndex = -1;

        public InputPatterns(char c)
        {
            _value = InputPatternDict.GetInputPattern(c);
        }

        public InputPattern SelectedPattern => _value[_selectedPatternIndex];
        public bool IsPatternSelected => _selectedPatternIndex != -1;

        public void Select(char a)
        {
            for (var i = 0; i < _value.Count; i++)
            {
                if (!_value[i].FirstChar(a)) continue;
                _selectedPatternIndex = i;
                SelectedPattern.AdvancePatternCharIndex();
            }
        }
    }
}