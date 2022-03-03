namespace Model
{
    public class Char
    {
        private readonly InputPatterns _inputPatterns;

        public Char(char c)
        {
            _inputPatterns = new InputPatterns(c);
        }


        public InputResult Input(Key key)
        {
            if (!_inputPatterns.IsPatternSelected)
            {
                _inputPatterns.Select(key.Value);
                if (!_inputPatterns.IsPatternSelected) return new Fail();
            }
            else
            {
                if (_inputPatterns.SelectedPattern.IsValidCurrentChar(key.Value))
                    _inputPatterns.SelectedPattern.AdvancePatternCharIndex();
                else
                    return new Fail();
            }

            return new Success(_inputPatterns.SelectedPattern.IsCompleted);
        }
    }
}