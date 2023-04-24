using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class LocalPlayerData : MonoBehaviour, ILocalPlayerData, ILocalPlayerDataForSetter
    {
        public Data.PlayerData PlayerData { get; set; }

        public List<GameObject> Enemies { get; set; }

        public Dictionary<GameObject, ILocalEnemyData> EnemiesData { get; set; }

        public int Health 
        { 
            get => health; 
            set { if (value <= MaxHealth) health = value; }
        }
        int health;

        public int MaxHealth { get; set; }
    }
}