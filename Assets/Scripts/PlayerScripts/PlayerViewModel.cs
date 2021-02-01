using System;
using UnityEngine;

namespace Shipov_Snake
{
    internal class PlayerViewModel : IMove
    {
        public event Action EndGame = delegate() { };
        public event Action Feed = delegate () { };

        private CircleCollider2D _collider2D;
        private LayerMask _layerMask;

        public bool IsDead { get; private set; }
        public PlayerModel PlayerModel { get; }

        public PlayerViewModel(PlayerModel player, LayerMask layerMask)
        {
            PlayerModel = player;
            PlayerModel.Player = GameObject.Instantiate(PlayerModel.Player, PlayerModel.Position, Quaternion.identity);
            _collider2D = PlayerModel.Player.GetComponent<CircleCollider2D>();
            _layerMask = layerMask;
        }

        public void Move()
        {
            PlayerModel.Player.transform.position += (Vector3)PlayerModel.Direction * PlayerModel.Speed;
        }

        public void OnTriggerEnterRealization()
        {
            var collider = Physics2D.OverlapCircle(_collider2D.transform.position, _collider2D.radius, _layerMask.value);
            if (collider != null)
            {
                if (collider.gameObject.CompareTag("Food"))
                {
                    collider.enabled = false; // Не очень нравится такой способ, если честно. Можно подсказать по этому поводу?
                    Eat();
                    collider.enabled = true; //
                }
                if (collider.gameObject.CompareTag("Wall") || collider.gameObject.CompareTag("Player"))
                {
                    Die();
                }
            }
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
