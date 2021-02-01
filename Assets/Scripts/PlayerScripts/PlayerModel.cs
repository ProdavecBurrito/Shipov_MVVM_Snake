using UnityEngine;

namespace Shipov_Snake
{
    internal class PlayerModel
    {
        public GameObject Player;
        public Vector2 Direction;
        public float TimeToMove;
        public int Size;
        public float Speed { get; }
        public Vector2 Position;

        public PlayerModel(PlayerSOData playerData)
        {
            Player = playerData.PlayerPrefab;
            Direction = playerData.StartDirection;
            TimeToMove = playerData.MaxTimeToMove;
            Position = playerData.StartPosition; 
            Size = playerData.StartSize;
            Speed = playerData.StartSpeed;
        }
    }
}
