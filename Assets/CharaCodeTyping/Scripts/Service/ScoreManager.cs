using UniRx;

namespace CharaCodeTyping.Scripts.Service
{
    public class ScoreManager
    {
        private readonly Question _question;
        public IntReactiveProperty CompleteCount { get; }
        public IntReactiveProperty FailCount { get; }
        public IntReactiveProperty TotalCount { get; }

        public ScoreManager(Question question)
        {
            _question = question;
            CompleteCount = new IntReactiveProperty(0);
            FailCount = new IntReactiveProperty(0);
            TotalCount = new IntReactiveProperty(0);
            
            Subscribe();
        }

        private void Subscribe()
        {
            _question.InputSuccessObservable
                .Subscribe(success =>
                {
                    TotalCount.Value++;

                    if (success is (_, true))
                    {
                        CompleteCount.Value++;
                    }
                });

            _question.InputFailObservable
                .Subscribe(_ =>
                {
                    TotalCount.Value++;
                    FailCount.Value++;
                });
        }
    }
}