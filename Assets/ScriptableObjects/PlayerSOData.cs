using UnityEngine;

namespace Shipov_Snake
{
    [CreateAssetMenu(fileName = "Snake", menuName = "Snake")]
    internal sealed class PlayerSOData : ScriptableObject
    {
        public int StartSize;
        public float StartSpeed;
    }
}
