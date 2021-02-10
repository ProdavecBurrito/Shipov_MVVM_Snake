using UnityEngine;

namespace Shipov_Snake
{
    internal class PlayerModel
    {
        public GameObject Player;
        public Vector2 Direction;
        public int BodySize;
        public float Speed { get; }
        public Vector2 Position;

        public PlayerModel(PlayerSOData playerData)
        {
            Direction = playerData.StartDirection;
            Position = playerData.StartPosition; 
            BodySize = playerData.StartSize;
            Speed = playerData.StartSpeed;
        }
    }
}
