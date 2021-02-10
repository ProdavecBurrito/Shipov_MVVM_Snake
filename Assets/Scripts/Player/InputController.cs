using UnityEngine;

namespace Shipov_Snake
{
    internal sealed class InputController : IUpdate
    {
        private const float MAX_VALUE = 1f;
        private const float MIN_VALUE = -1f;
        private const float ZERO_VALUE = 0.0f;

        private PlayerViewModel _playerView;
        private KeyCode _up = KeyCode.W;
        private KeyCode _down = KeyCode.S;
        private KeyCode _left = KeyCode.A;
        private KeyCode _right = KeyCode.D;

        public InputController(PlayerViewModel playerView)
        {
            _playerView = playerView;
        }

        public void UpdateTick()
        {
            if (Input.GetKeyDown(_up))
            {
                _playerView.PlayerModel.Direction.x = ZERO_VALUE;
                _playerView.PlayerModel.Direction.y = MAX_VALUE;
            }
            if (Input.GetKeyDown(_down))
            {
                _playerView.PlayerModel.Direction.x = ZERO_VALUE;
                _playerView.PlayerModel.Direction.y = MIN_VALUE;
            }
            if (Input.GetKeyDown(_left))
            {
                _playerView.PlayerModel.Direction.x = MIN_VALUE;
                _playerView.PlayerModel.Direction.y = ZERO_VALUE;
            }
            if (Input.GetKeyDown(_right))
            {
                _playerView.PlayerModel.Direction.x = MAX_VALUE;
                _playerView.PlayerModel.Direction.y = ZERO_VALUE;
            }
        }
    }
}
