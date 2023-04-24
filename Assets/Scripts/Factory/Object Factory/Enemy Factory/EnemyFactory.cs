using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class EnemyFactory : GameObjectFactory, IEnemyFactory
    {
        [SerializeField] GameObject prefab;

        readonly IDataSetterForEnableEnemy DataSetterForEnableEnemy = new DataSetterForEnableEnemy();

        public Dictionary<GameObject, ILocalEnemyData> Enemies { get => enemies; }
        readonly Dictionary<GameObject, ILocalEnemyData> enemies = new ();

        public GameObject CreateEnemy(Vector3 position)
        {
            GameObject enemy;
            bool newEnemy;

            (enemy, newEnemy) = Create(prefab);

            enemy.transform.position = position;

            if (newEnemy)
            {
                Enemies.Add(enemy, enemy.GetComponent<ILocalEnemyData>());
                enemy.GetComponent<ILocalEnemyDataForSetter>().MyFactory = this;
            }
            else
                DataSetterForEnableEnemy.SetDataForEnableEnemy(enemy, Enemies);

            return enemy;
        }
    }
}