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
        private CircleCollider2D _collider2D;
        private LayerMask _layerMask;
        private List<Vector2> _positionPoints;
        private SnakeTail _snakeTail;

        public bool IsDead { get; private set; }
        public PlayerModel PlayerModel { get; }

        public PlayerViewModel(PlayerModel player, LayerMask layerMask, SnakeTail snakeTail)
        {
            _timer = new Timer();
            PlayerModel = player;
            PlayerModel.Player = GameObject.Instantiate(PlayerModel.Player, PlayerModel.Position, Quaternion.identity);
            _collider2D = PlayerModel.Player.GetComponent<CircleCollider2D>();
            _layerMask = layerMask;
            _positionPoints = new List<Vector2>();
            _snakeTail = snakeTail;
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
            var collider = Physics2D.OverlapCircle(_collider2D.transform.position, _collider2D.radius, _layerMask.value);
            if (collider != null)
            {
                if (collider.gameObject.CompareTag("Food"))
                {
                    collider.enabled = false; // Не очень нравится такой способ, если честно. Можно подсказать по этому поводу?
                    Eat();
                    collider.enabled = true; // Это сделанно так, изза того, что колайдеры могут пересечься несколько раз и тогда Eat так же вызывается несколько раз
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

        private void SpawnTail() // Мне кажется, это вообще не ответственность этого класса и обьекта в целом. Если я прав - то как это лучше сделать?
        {
            var lastPositionIndex = _positionPoints.Count - 1;
            _snakeTail.AddTailMember(GameObject.Instantiate(Resources.Load<GameObject>("SnakeTail")), _positionPoints[lastPositionIndex]);
        }

        public void Eat()
        {
            PlayerModel.BodySize ++;
            Feed?.Invoke();
            SpawnTail();
        }

        public void Die()
        {
            IsDead = true;
            EndGame?.Invoke();
        }
    }
}
