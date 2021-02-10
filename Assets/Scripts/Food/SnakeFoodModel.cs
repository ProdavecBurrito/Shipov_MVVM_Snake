using UnityEngine;

namespace Shipov_Snake
{
    internal class SnakeFoodModel
    {
        public GameObject Food;
        public Vector2 Position;
        public float ScoreValue;

        public SnakeFoodModel(FoodSO food)
        {
            Position = food.Position;
            ScoreValue = food.ScoreValue;
        }
    }
}
