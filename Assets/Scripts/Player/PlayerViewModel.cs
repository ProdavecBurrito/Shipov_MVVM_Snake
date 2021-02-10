using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Snake
{
    internal class PlayerViewModel : IMove
    {
        public event Action EndGame = delegate() { };
        public event Action Feed = delegate () { };

        private Timer _timer;
        private CircleCollider2D _playerCollider;
        private List<Vector2> _positionPoints;
        private SnakeTail _snakeTail;
        private Factory _factory;

        private LayerMask _layerMask;

        public bool IsDead { get; private set; }
        public PlayerModel PlayerModel { get; }

        public PlayerViewModel(PlayerModel player, LayerMask layerMask, SnakeTail snakeTail, Factory factory)
        {
            _timer = new Timer();
            PlayerModel = player;
            PlayerModel.Player = factory.Create("SnakeHead", PlayerModel.Position, Quaternion.identity);
            _playerCollider = PlayerModel.Player.GetComponent<CircleCollider2D>();
            _layerMask = layerMask;
            _positionPoints = new List<Vector2>();
            _snakeTail = snakeTail;
            _factory = factory;

            Feed += SpawnTailMember;
        }

        public void Move()
        {
            if (!_timer.IsOn)
            {
                RememberPosition();
                PlayerModel.Player.transform.position += (Vector3)PlayerModel.Direction * PlayerModel.Speed;
                _snakeTail.Move(_positionPoints);
                _timer.Init(0.25f);
            }
            else
            {
                _timer.CountTime();
            }
        }

        public void OnTriggerEnterRealization()
        {
            var collider = Physics2D.OverlapCircle(_playerCollider.transform.position, _playerCollider.radius, _layerMask.value);
            if (collider != null)
            {
                if (collider.gameObject.CompareTag("Food"))
                {
                    collider.enabled = false;
                    Eat();
                    collider.enabled = true;
                }
                if (collider.gameObject.CompareTag("Wall") || collider.gameObject.CompareTag("Tail"))
                {
                    Die();
                }
            }
        }

        private void RememberPosition()
        {
            _positionPoints.Insert(0, PlayerModel.Player.transform.position);
            if (_positionPoints.Count > PlayerModel.BodySize)
            {
                _positionPoints.RemoveAt(_positionPoints.Count - 1);
            }
        }

        private void SpawnTailMember()
        {
            var lastPositionIndex = _positionPoints.Count - 1;
            _snakeTail.AddTailMember(_factory.Create("SnakeTail"), _positionPoints[lastPositionIndex]);
        }

        public void Eat()
        {
            PlayerModel.BodySize ++;
            Feed?.Invoke();
        }

        public void Die()
        {
            IsDead = true;
            EndGame?.Invoke();
        }
    }
}
