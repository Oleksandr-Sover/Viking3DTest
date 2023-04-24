using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IPlayerAttackDistanceHandler
    {
        List<GameObject> EnemiesInAffectedArea { get; }
    }
}