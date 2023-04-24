using UnityEngine;

namespace GameLogic
{
    public interface IPlayerMovement
    {
        void Move(Vector2 inputMove, float speed, float rotationSmoothTime);
    }
}