using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class GameObjectFactory : MonoBehaviour, IFactory<GameObject>
    {
        public List<GameObject> ActiveObjects { get => GOPool.ActiveGO; }

        readonly IGameObjectPool GOPool = new GameObjectPool();

        public (GameObject, bool newObject) Create(GameObject prefab)
        {
            if (GOPool.DeactiveGOPoolCount > 0)
            {
                GameObject go = GOPool.PullOutDisableGO();
                GOPool.EnableGO(go);
                return (go, false);
            }
            else
            {
                GameObject go = Instantiate(prefab);
                GOPool.EnableGO(go);
                return (go, true);
            }
        }
        public void Destroy(GameObject objectToDestroy) => GOPool.DisableGO(objectToDestroy);
    }
}