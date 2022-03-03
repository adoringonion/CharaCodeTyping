namespace CharaCodeTyping.Scripts.Model
{
    public class InputPattern
    {
        private readonly string _value;
        private int _currentPatternCharIndex;

        public InputPattern(string value)
        {
            _value = value;
            _currentPatternCharIndex = 0;
        }

        public bool IsCompleted => _currentPatternCharIndex == _value.Length;

        public bool FirstChar(char c)
        {
            return _value[0].Equals(c);
        }

        public bool IsValidCurrentChar(char c)
        {
            return _value[_currentPatternCharIndex] == c;
        }

        public void AdvancePatternCharIndex()
        {
            _currentPatternCharIndex ++;
        }
    }
}