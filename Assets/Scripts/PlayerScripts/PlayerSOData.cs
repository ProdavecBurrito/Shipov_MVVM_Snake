using UnityEngine;

namespace Shipov_Snake
{
    [CreateAssetMenu(fileName = "Snake", menuName = "Snake")]
    internal sealed class PlayerSOData : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public Vector2 StartDirection;
        public Vector2 StartPosition;
        public float MaxTimeToMove;
        public int StartSize;
        public float StartSpeed;
    }
}
