using UnityEngine;

namespace GameLogic
{
    public class LocalEnemyDataSetter : MonoBehaviour
    {
        [SerializeField] Data.MutantData mutantData;

        ILocalEnemyDataForSetter LocalEnemyDataForSetter;

        void Awake()
        {
            LocalEnemyDataForSetter = GetComponent<ILocalEnemyDataForSetter>();

            GameObject target = GameObject.FindGameObjectWithTag("Player");
            
            LocalEnemyDataForSetter.TargetTransform = target.transform;

            if (target.TryGetComponent<ILocalPlayerData>(out _))
                LocalEnemyDataForSetter.LocalPlayerData = target.GetComponent<ILocalPlayerData>();

            LocalEnemyDataForSetter.MutantData = mutantData;
            LocalEnemyDataForSetter.Health = mutantData.Health;

            LocalEnemyDataForSetter.ThisGameObject = gameObject;
            LocalEnemyDataForSetter.ThisTransform = gameObject.transform;
            LocalEnemyDataForSetter.CharacterController = GetComponent<CharacterController>();

            LocalEnemyDataForSetter.EnemyController = GetComponent<IEnemyController>();
        }
    }
}