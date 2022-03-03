namespace CharaCodeTyping.Scripts.Model
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
                if (!_inputPatterns.IsPatternSelected) return InputResult.Fail;
            }
            else
            {
                if (_inputPatterns.SelectedPattern.IsValidCurrentChar(key.Value))
                    _inputPatterns.SelectedPattern.AdvancePatternCharIndex();
                else
                    return InputResult.Fail;
            }

            return _inputPatterns.SelectedPattern.IsCompleted ? InputResult.Complete : InputResult.Success;
        }
    }
}