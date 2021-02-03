using UnityEngine;
using UnityEngine.UI;

namespace Shipov_Snake
{
    internal class EndGame
    {
        private Canvas _endGameCanvas;
        private PlayerViewModel _playerViewModel;
        private GameSpeed _gameSpeed;
        private Button _restartButton;

        public EndGame(PlayerViewModel playerViewModel, GameSpeed gameSpeed)
        {
            _endGameCanvas = GameObject.Instantiate(Resources.Load<Canvas>("EndGameCanvas"));
            _endGameCanvas.gameObject.SetActive(false);
            _gameSpeed = gameSpeed;

            _restartButton = _endGameCanvas.GetComponentInChildren<Button>();
            _restartButton.onClick.AddListener(_gameSpeed.RestartGame);
            _playerViewModel = playerViewModel;

            _playerViewModel.EndGame += GameOver;
        }

        private void GameOver()
        {
            _gameSpeed.StopGame();
            _endGameCanvas.gameObject.SetActive(true);
        }
    }
}
