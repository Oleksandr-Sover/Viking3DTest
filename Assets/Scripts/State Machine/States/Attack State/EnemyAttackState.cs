using UnityEngine;

namespace GameLogic
{
    public class EnemyAttackState : CharacterAttackState
    {
        ILocalEnemyData LocalEnemyData;
        IEnemyAttackDistanceHandler EnemyAttackDistanceHandler;
        IEnemyAttackCornerHandler EnemyAttackCornerHandler;

        protected override Vector2 RotateDirection { get => GetMoveDirection(); }
        protected override float SpeedChangeRate { get; set; }

        Transform targetTransform;

        bool inAffectedCornerArea;
        bool inAffectedDistanceArea;

        protected override void Awake()
        {
            base.Awake();

            LocalEnemyData = GetComponentInParent<ILocalEnemyData>();
            EnemyAttackDistanceHandler = GetComponent<IEnemyAttackDistanceHandler>();
            EnemyAttackCornerHandler = GetComponent<IEnemyAttackCornerHandler>();
        }

        void Start()
        {
            SpeedChangeRate = LocalEnemyData.MutantData.SpeedChangeRate;
            targetTransform = LocalEnemyData.TargetTransform;
            rotationSmoothTime = LocalEnemyData.MutantData.RotationSmoothTime;
        }

        public override void Execute()
        {
            base.Execute();

            if (attackAchieved && !damageIsDone)
            {
                inAffectedDistanceArea = EnemyAttackDistanceHandler.TargetInAffectedArea();

                if (inAffectedDistanceArea)
                {
                    inAffectedCornerArea = EnemyAttackCornerHandler.TargetInAffectedArea();

                    if (inAffectedCornerArea)
                    {
                        LocalEnemyData.TargetHealth -= LocalEnemyData.MutantData.Damage;
                        damageIsDone = true;
                    }
                }
            }
        }

        Vector2 GetMoveDirection()
        {
            Vector3 distance = targetTransform.position - transform.position;
            Vector2 moveDirection = new (distance.x, distance.z);
            return moveDirection;
        }
    }
}