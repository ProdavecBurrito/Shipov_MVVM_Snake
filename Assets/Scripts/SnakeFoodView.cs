using UnityEngine;

namespace Shipov_Snake
{
    internal class SnakeFoodView : MonoBehaviour
    {
        private SnakeFoodViewModel _snakeFoodViewModel;

        public void Initialize(SnakeFoodViewModel snakeFoodViewModel, PlayerViewModel playerViewModel)
        {
            _snakeFoodViewModel = snakeFoodViewModel;
            playerViewModel.Feed += _snakeFoodViewModel.Move;
        }
    }
}
