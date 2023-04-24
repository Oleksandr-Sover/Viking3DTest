using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GlobalData", menuName = "Data/GlobalData", order = 1)]
    public class GlobalData : ScriptableObject
    {
        public int Score { get; set; }


        [Header("Environment")]

        [SerializeField] LayerMask terrainLayer;
        public LayerMask TerrainLayer { get => terrainLayer; }


        [Header("Gravitation")]

        [SerializeField] float gravity = -9.81f;
        public float Gravity { get => gravity; }


        [Header("Enemy Settings")]

        [SerializeField] int maxNumberOfEnemies = 10;
        public int MaxNumberOfEnemies { get => maxNumberOfEnemies; }


        [SerializeField] float distanceToPlayer = 30;
        public float DistanceToPlayer { get => distanceToPlayer; }


        [SerializeField] float startingAltitudeAboveGround = 2;
        public float StartingAltitudeAboveGround { get => startingAltitudeAboveGround; }
    }
}