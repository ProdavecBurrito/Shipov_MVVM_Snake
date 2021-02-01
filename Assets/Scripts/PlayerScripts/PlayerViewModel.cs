using System;
using UnityEngine;

namespace Shipov_Snake
{
    internal class PlayerViewModel : IMove
    {
        public event Action EndGame = delegate() { };
        public event Action Feed = delegate () { };

        public bool IsDead { get; private set; }
        public PlayerModel PlayerModel { get; }

        public PlayerViewModel(PlayerModel player)
        {
            PlayerModel = player;
            PlayerModel.Player = GameObject.Instantiate(PlayerModel.Player, PlayerModel.Position, Quaternion.identity);
        }

        public void Move()
        {
            PlayerModel.Player.transform.position += (Vector3)PlayerModel.Direction * PlayerModel.Speed;
        }

        public void Eat()
        {
            PlayerModel.Size += 1;
            Feed?.Invoke();
        }

        public void Die()
        {
            IsDead = true;
            EndGame?.Invoke();
        }
    }
}
