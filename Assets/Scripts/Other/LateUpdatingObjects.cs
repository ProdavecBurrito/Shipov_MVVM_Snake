using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Snake
{
    internal class LateUpdatingObjects
    {
        private List<ILateUpdate> _updatingObjects;
        public int Count => _updatingObjects.Count;

        public void AddUpdateObject(ILateUpdate updatingObject)
        {
            if (_updatingObjects == null)
            {
                _updatingObjects = new List<ILateUpdate>();
            }
            _updatingObjects.Add(updatingObject);
        }

        public void RemoveUpdatingObject(ILateUpdate updatingObject)
        {
            _updatingObjects.Remove(updatingObject);
        }

        public ILateUpdate this[int index]
        {
            get => _updatingObjects[index];
            private set => _updatingObjects[index] = value;
        }
    }
}
