using UnityEngine;
using UnityEngine.UI;

namespace Shipov_Snake
{
    internal sealed class Initializator
    {
        public Factory Factory { get; private set; }
        public PlayerView PlayerView { get; private set; }
        public PlayerViewModel PlayerViewModel { get; private set; }
        public InputController InputController { get; private set; }
        public SnakeFoodView SnakeFoodView { get; private set; }
        public SnakeFoodViewModel SnakeFoodViewModel { get; private set; }
        public ScoreView ScoreView { get; private set; }
        public GameSpeed GameSpeed { get; private set; }
        public EndGame EndGame { get; private set; }
        public SnakeTail SnakeTail { get; private set; }

        public Initializator(PlayerSOData playerSO, FoodSO foodSO, LayerMask layerMask, Text text)
        {
            Factory = new Factory();

            SnakeTail = new SnakeTail();
            var playerData = new PlayerModel(playerSO);
            PlayerViewModel = new PlayerViewModel(playerData, layerMask, SnakeTail, Factory);
            PlayerView = new PlayerView();
            PlayerView.Initialize(PlayerViewModel);
            InputController = new InputController(PlayerViewModel);

            var foodData = new SnakeFoodModel(foodSO);
            SnakeFoodViewModel = new SnakeFoodViewModel(foodData, Factory);
            SnakeFoodView = new SnakeFoodView();
            SnakeFoodView.Initialize(SnakeFoodViewModel, PlayerViewModel);

            ScoreView = new ScoreView();
            ScoreView.Init(text, PlayerViewModel, SnakeFoodViewModel);

            GameSpeed = new GameSpeed();

            EndGame = new EndGame(PlayerViewModel, GameSpeed);
        }
    }
}
