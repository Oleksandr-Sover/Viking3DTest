using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IEnemyFactory
    {
        List<GameObject> ActiveObjects { get; }
        Dictionary<GameObject, ILocalEnemyData> Enemies { get; }
        GameObject CreateEnemy(Vector3 position);
        void Destroy(GameObject objectToDestroy);
    }
}