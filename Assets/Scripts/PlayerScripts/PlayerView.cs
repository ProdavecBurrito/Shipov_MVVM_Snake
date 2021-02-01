using UnityEngine;

namespace Shipov_Snake
{
    internal class PlayerView : MonoBehaviour, IUpdate
    {
        private PlayerViewModel _playerViewModel;
        private CircleCollider2D _collider2D;
        private Collider2D _hitCollider;

        public void Initialize(PlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;
            _collider2D = _playerViewModel.PlayerModel.Player.GetComponent<CircleCollider2D>();
        }

        public void UpdateTick()
        {
            _playerViewModel.Move();
            Kek();
        }

        public void Kek()
        {
            if ( Physics2D.OverlapCircle(_collider2D.transform.position, _collider2D.radius))
            {
                var kek = Physics2D.OverlapCircle(_collider2D.transform.position, _collider2D.radius);
                if (kek.gameObject.CompareTag("Food"))
                {
                    Debug.Log("Meh");
                    _playerViewModel.Eat();
                }
                if (kek.gameObject.CompareTag("Wall") /*|| kek.gameObject.CompareTag("Player")*/)
                {
                    Debug.Log("Bre");
                    _playerViewModel.Die();
                }
            }
        }
    }
}
