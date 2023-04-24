using UnityEngine;

namespace GameLogic
{
    public interface IPlayerAttackCornerHandler
    {
        bool InAffectedArea(Vector3 targetPosition);
    }
}