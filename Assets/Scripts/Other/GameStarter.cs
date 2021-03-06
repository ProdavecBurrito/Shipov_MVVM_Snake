using UnityEngine.UI;
using UnityEngine;
using System;

namespace Shipov_Snake
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private PlayerSOData _playerSO;
        [SerializeField] private FoodSO _foodSO;
        [SerializeField] private Text _scoreText;
        [SerializeField] private LayerMask _layerMask;

        private UpdatingObjects _updatingObjects;
        private Initializator _initializator;

        private void Start()
        {
            _updatingObjects = new UpdatingObjects();
            _initializator = new Initializator(_playerSO, _foodSO, _layerMask, _scoreText);

            _updatingObjects.AddUpdateObject(_initializator.PlayerView);
            _updatingObjects.AddUpdateObject(_initializator.InputController);
        }

        private void Update()
        {
            for(int i = 0; i < _updatingObjects.Count; i++)
            {
                _updatingObjects[i].UpdateTick();
            }
        }
    }
}
