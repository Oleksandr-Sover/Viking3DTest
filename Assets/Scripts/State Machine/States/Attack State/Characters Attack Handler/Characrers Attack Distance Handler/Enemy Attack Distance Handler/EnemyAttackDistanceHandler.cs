using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public class EnemyAttackDistanceHandler : MonoBehaviour, IEnemyAttackDistanceHandler
    {
        ILocalEnemyData LocalEnemyData;

        public bool TargetWasInAffectedArea { get; private set; }

        readonly WaitForSeconds waitSec = new (1);

        Transform targetTransform;

        float sqrMaxDistance;

        bool isCoroutineWorks;

        void Awake()
        {
            LocalEnemyData = GetComponentInParent<ILocalEnemyData>();
        }

        void Start()
        {
            sqrMaxDistance = LocalEnemyData.MutantData.AttackDistance * LocalEnemyData.MutantData.AttackDistance;
            targetTransform = LocalEnemyData.TargetTransform;
        }

        void LateUpdate()
        {
            if (!isCoroutineWorks)
                StartCoroutine(DetermineIfTargetIsInAffectedArea());
        }

        void OnDisable()
        {
            StopCoroutine(DetermineIfTargetIsInAffectedArea());
            isCoroutineWorks = false;
        }

        IEnumerator DetermineIfTargetIsInAffectedArea()
        {
            isCoroutineWorks = true;

            TargetWasInAffectedArea = TargetInAffectedArea();

            yield return waitSec;

            isCoroutineWorks = false;
        }

        public bool TargetInAffectedArea()
        {
            Vector3 enemyPosition = targetTransform.position;
            enemyPosition.y = transform.position.y;
            float sqrDistance = (enemyPosition - transform.position).sqrMagnitude;

            if (sqrDistance < sqrMaxDistance)
                return true;
            else
                return false;
        }
    }
}