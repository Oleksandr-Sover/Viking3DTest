using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface ILocalPlayerData
    {
        Data.PlayerData PlayerData { get; }
        List<GameObject> Enemies { get; }
        Dictionary<GameObject, ILocalEnemyData> EnemiesData { get; }
        int Health { get; set; }
    }
}