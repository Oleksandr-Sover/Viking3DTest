using UnityEngine;

namespace GameLogic
{
    public class EnemyAttackCornerHandler : CharactersAttackCornerHandler, IEnemyAttackCornerHandler
    {
        ILocalEnemyData LocalEnemyData;

        Transform targetTransform;

        protected override int AngleOfAttack { get; set; }

        void Awake()
        {
            LocalEnemyData = GetComponentInParent<ILocalEnemyData>();
        }

        protected override void Start()
        {
            AngleOfAttack = LocalEnemyData.MutantData.AngleOfAttack;
            base.Start();

            targetTransform = LocalEnemyData.TargetTransform;
        }

        public bool TargetInAffectedArea() => InAffectedArea(targetTransform.position);
    }
}