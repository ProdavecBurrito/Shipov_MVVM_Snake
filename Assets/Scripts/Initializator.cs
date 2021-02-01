using UnityEngine;
using UnityEngine.UI;

namespace Shipov_Snake
{
    internal class Initializator
    {
        public PlayerView PlayerView { get; private set; }
        public PlayerViewModel PlayerViewModel { get; private set; }
        public InputController InputController { get; private set; }

        public SnakeFoodView SnakeFoodView { get; private set; }
        public SnakeFoodViewModel SnakeFoodViewModel { get; private set; }

        public Initializator(PlayerSOData playerSO, FoodSO foodSO)
        {
            var playerData = new PlayerModel(playerSO);
            PlayerViewModel = new PlayerViewModel(playerData);
            PlayerView = new PlayerView();
            PlayerView.Initialize(PlayerViewModel);
            InputController = new InputController(PlayerViewModel);

            var foodData = new SnakeFoodModel(foodSO);
            SnakeFoodViewModel = new SnakeFoodViewModel(foodData);
            SnakeFoodView = new SnakeFoodView();
            SnakeFoodView.Initialize(SnakeFoodViewModel, PlayerViewModel);
        }
    }
}
