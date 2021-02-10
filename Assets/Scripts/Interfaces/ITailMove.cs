using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Snake
{
    internal interface ITailMove
    {
        void Move(List<Vector2> vector);
    }
}