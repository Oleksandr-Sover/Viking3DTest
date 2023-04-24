using UnityEngine;

namespace GameLogic
{
    public class LocalEnemyData : MonoBehaviour, ILocalEnemyData, ILocalEnemyDataForSetter
    {
        public Data.MutantData MutantData { get; set; }

        public IEnemyFactory MyFactory { get; set; }

        public ILocalPlayerData LocalPlayerData { get; set; }

        public IEnemyController EnemyController { get; set; }

        public GameObject ThisGameObject { get; set; }

        public CharacterController CharacterController { get; set; }

        public Transform TargetTransform { get; set; }

        public Transform ThisTransform { get; set; }

        public int Health { get; set; }

        public int TargetHealth { get => LocalPlayerData.Health; set => LocalPlayerData.Health = value; }
    }
}