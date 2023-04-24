using UnityEngine;

namespace GameLogic
{
    public class LocalPlayerDataSetter : MonoBehaviour
    {
        [SerializeField] Data.PlayerData playerData;

        ILocalPlayerDataForSetter LocalPlayerDataForSetter;

        IEnemyFactory EnemyFactory { get => enemyFactory; }
        [SerializeField] EnemyFactory enemyFactory;

        int pastNumberOfEnemies = 0;

        void Awake()
        {
            LocalPlayerDataForSetter = GetComponent<ILocalPlayerDataForSetter>();

            LocalPlayerDataForSetter.PlayerData = playerData;
            LocalPlayerDataForSetter.MaxHealth = playerData.Health;
            LocalPlayerDataForSetter.Health = playerData.Health;
            LocalPlayerDataForSetter.EnemiesData = EnemyFactory.Enemies;
            LocalPlayerDataForSetter.Enemies = new ();
        }

        void Update()
        {
            UpdateCurrentEnemies();
        }

        void UpdateCurrentEnemies()
        {
            int count = EnemyFactory.ActiveObjects.Count;

            if (count != pastNumberOfEnemies)
            {
                pastNumberOfEnemies = count;

                LocalPlayerDataForSetter.Enemies.Clear();
                LocalPlayerDataForSetter.Enemies.AddRange(EnemyFactory.ActiveObjects);
            }
        }
    }
}