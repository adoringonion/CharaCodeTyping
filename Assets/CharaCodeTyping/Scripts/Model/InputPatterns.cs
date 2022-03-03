namespace CharaCodeTyping.Scripts.Model
{
    public class InputPatterns
    {
        private readonly InputPattern[] _value;
        private int _selectedPatternIndex = -1;

        public InputPatterns(char c)
        {
            _value = InputPatternDict.GetInputPattern(c);
        }

        public InputPattern SelectedPattern => _value[_selectedPatternIndex];
        public bool IsPatternSelected => _selectedPatternIndex != -1;

        public void Select(char c)
        {
            for (var i = 0; i < _value.Length; i++)
            {
                if (!_value[i].FirstChar(c)) continue;
                _selectedPatternIndex = i;
                SelectedPattern.AdvancePatternCharIndex();
            }
        }
    }
}