using UnityEngine;

namespace GameLogic
{
    public interface IInputController
    {
        Vector2 Move { get; }
        Vector2 Look { get; }
        float InputMagnitude { get; }
        float DeltaTimeMultiplier { get; }
        bool Sprint { get; }
        bool Attack { get; }
        bool IsCurrentDeviceMouse { get; }
    }
}