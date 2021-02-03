using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Snake
{
    internal class SnakeTail : ITailMove
    {
        private List<GameObject> _snakeTails;

        public SnakeTail()
        {
            _snakeTails = new List<GameObject>();
        }

        public void Move(List<Vector2> vectors)
        {
            for (int i = 0; i < _snakeTails.Count; i++)
            {
                _snakeTails[i].transform.position = vectors[i];
            }
        }

        public void AddTailMember(GameObject tail, Vector3 vector)
        {
            _snakeTails.Add(tail);
            tail.transform.position = vector;
        }
    }
}
