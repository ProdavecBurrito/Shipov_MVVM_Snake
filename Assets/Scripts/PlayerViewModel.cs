using System;
using UnityEngine;

namespace Shipov_Snake
{
    internal class PlayerViewModel : IMove, IUpdate
    {
        public event Action EndGame = delegate() { };
        public event Action Feed = delegate () { };

        public bool IsDead { get; private set; }
        public PlayerModel Player { get; }

        public PlayerViewModel(PlayerModel player)
        {
            Player = player;
        }

        public void UpdateTick()
        {
            Move();
        }

        public void Move()
        {

        }

        public void Eat()
        {
            Player.Size += 1;
            Feed?.Invoke();
        }

        public void Die()
        {
            IsDead = true;
            EndGame?.Invoke();
        }
    }
}
