using UnityEngine;

namespace Shipov_Snake
{
    [CreateAssetMenu(fileName = "Food", menuName = "Food")]
    internal sealed class FoodSO : ScriptableObject
    {
        public GameObject FoodPrefab;
        public Vector2 Position;
        public float ScoreValue;
    }
}
