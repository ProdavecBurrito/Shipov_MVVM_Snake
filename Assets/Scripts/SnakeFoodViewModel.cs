using UnityEngine;

namespace Shipov_Snake
{
    internal class SnakeFoodViewModel : IMove
    {
        private const float MAX_POSITION = 3.5f;
        private const float MIN_POSITION = -3.5f;

        public bool IsEaten;
        public Collider2D SnakeCollider;

        public SnakeFoodModel FoodModel { get; }

        public SnakeFoodViewModel(SnakeFoodModel foodModel)
        {
            FoodModel = foodModel;
            FoodModel.Food = GameObject.Instantiate(FoodModel.Food, FoodModel.Position, Quaternion.identity);
            SnakeCollider = foodModel.Food.GetComponent<Collider2D>();
        }

        public void Move()
        {
            FoodModel.Position.x = Random.Range(MIN_POSITION, MAX_POSITION);
            FoodModel.Position.y = Random.Range(MIN_POSITION, MAX_POSITION);
            FoodModel.Food.transform.position = new Vector2(FoodModel.Position.x, FoodModel.Position.y);
        }
    }
}
