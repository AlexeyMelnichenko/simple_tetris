using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameScreen : ScreenWithIntent<GameScreenIntent>
    {
        [SerializeField] private Transform _gameViewRoot;
        [SerializeField] private Vector3 _gameViewScale;
        [SerializeField] private Vector3 _gameViewPosition;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _linesText;
        private Game _game;

        protected override void OnScreenInitialized()
        {
            _game = Instantiate(Intent.GamePerfab, _gameViewRoot);
            _game.transform.localScale = _gameViewScale;
            _game.transform.localPosition = _gameViewPosition;
            _game.Init();

            SubscribeOnGameEvents();

            UpdateLinesText(_game.Lines);
            UpdateScoreText(_game.Score);
        }

        private void SubscribeOnGameEvents()
        {
            _game.ScoreChanged += UpdateScoreText;
            _game.LinesChanged += UpdateLinesText;
        }

        private void UnsubscribeFromGameEvents()
        {
            _game.ScoreChanged -= UpdateScoreText;
            _game.LinesChanged -= UpdateLinesText;
        }

        private void UpdateLinesText(int lines)
        {
            _linesText.text = lines.ToString();
        }

        private void UpdateScoreText(int score)
        {
            _scoreText.text = score.ToString();
        }

        private void OnDestroy()
        {
            UnsubscribeFromGameEvents();
        }
    }

    public class GameScreenIntent : EmptyIntent
    {
        public GameScreenIntent(Game gamePerfab)
        {
            this.GamePerfab = gamePerfab;
        }

        public Game GamePerfab { get; }
    }
}
