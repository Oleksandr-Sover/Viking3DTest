using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class DataSetterForEnableEnemy: IDataSetterForEnableEnemy
    {
        public void SetDataForEnableEnemy(GameObject enemy, Dictionary<GameObject, ILocalEnemyData> enemiesData)
        {
            enemiesData[enemy].Health = enemiesData[enemy].MutantData.Health;
            enemiesData[enemy].EnemyController.SetStartHealthForDamageHandler();
            enemiesData[enemy].CharacterController.enabled = true;
        }
    }
}