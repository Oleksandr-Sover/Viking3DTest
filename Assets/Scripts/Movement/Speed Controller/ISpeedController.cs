using UnityEngine;

namespace GameLogic
{
    public interface ISpeedController
    {
        float GetSpeed(Vector2 inputMove, float inputMagnitude, float sprintSpeed, float moveSpeed, float speedChangeRate, bool isSprint);
    }
}