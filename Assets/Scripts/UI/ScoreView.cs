using UnityEngine.UI;

namespace Shipov_Snake
{
    internal class ScoreView
    {
        private int _currentScore;
        private PlayerViewModel _playerViewModel;
        private SnakeFoodViewModel _snakeFoodViewModel;

        public Text ScoreText { get; private set; }

        public void Init(Text text, PlayerViewModel playerViewModel, SnakeFoodViewModel snakeFoodViewModel)
        {
            ScoreText = text;
            _playerViewModel = playerViewModel;
            _playerViewModel.Feed += AddScore;
            _snakeFoodViewModel = snakeFoodViewModel;
        }

        public void AddScore()
        {
            _currentScore += (int)_snakeFoodViewModel.FoodModel.ScoreValue ;
            ScoreText.text = _currentScore.ToString();
        }
    }
}
