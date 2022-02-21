namespace Model
{
    public class InputPattern
    {
        private readonly string _value;
        private int _currentPatternCharIndex;

        public InputPattern(string value)
        {
            _value = value;
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
            _currentPatternCharIndex += 1;
        }
    }
}