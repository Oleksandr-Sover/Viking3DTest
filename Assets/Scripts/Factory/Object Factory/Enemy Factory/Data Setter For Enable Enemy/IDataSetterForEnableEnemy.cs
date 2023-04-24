using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IDataSetterForEnableEnemy
    {
        void SetDataForEnableEnemy(GameObject enemy, Dictionary<GameObject, ILocalEnemyData> enemiesData);
    }
}