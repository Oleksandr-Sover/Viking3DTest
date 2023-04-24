using UnityEngine;

namespace GameLogic
{
    public interface IEnemyMovement
    {
        void Move(Vector3 distance, float speed, float rotationSmoothTime);
    }
}