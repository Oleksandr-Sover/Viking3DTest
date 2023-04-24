using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface ILocalPlayerDataForSetter
    {
        Data.PlayerData PlayerData { get; set; }
        List<GameObject> Enemies { get; set; }
        Dictionary<GameObject, ILocalEnemyData> EnemiesData { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
    }
}