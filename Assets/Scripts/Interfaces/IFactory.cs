using UnityEngine;

namespace Shipov_Snake
{
    internal interface IFactory
    {
        GameObject Create(string objectLocation);
    }
}
