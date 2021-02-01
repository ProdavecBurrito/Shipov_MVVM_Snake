using UnityEngine;

namespace Shipov_Snake
{
    internal class SnakeFoodViewModel : IMove
    {
        public bool IsEaten;
        public SnakeFoodModel FoodModel { get; }
        public Collider2D SnakeCollider;
        public SnakeFoodViewModel(SnakeFoodModel foodModel)
        {
            FoodModel = foodModel;
            FoodModel.Food = GameObject.Instantiate(FoodModel.Food, FoodModel.Position, Quaternion.identity);
            SnakeCollider = foodModel.Food.GetComponent<Collider2D>();
        }

        public void Move()
        {
            FoodModel.Position.x = Random.Range(-3.5f, 3.5f);
            FoodModel.Position.y = Random.Range(-3.5f, 3.5f);
        }
    }
}
