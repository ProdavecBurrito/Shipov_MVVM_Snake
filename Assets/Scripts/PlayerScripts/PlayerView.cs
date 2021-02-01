using UnityEngine;

namespace Shipov_Snake
{
    internal class PlayerView :IUpdate
    {
        private PlayerViewModel _playerViewModel;

        public void Initialize(PlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;
        }

        public void UpdateTick()
        {
            _playerViewModel.Move();
            _playerViewModel.OnTriggerEnterRealization();
        }
    }
}
