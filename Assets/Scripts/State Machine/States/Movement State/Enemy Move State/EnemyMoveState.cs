using UnityEngine;

namespace GameLogic
{
    public class EnemyMoveState : CharacterMoveState
    {
        ILocalEnemyData LocalEnemyData;
        IEnemyMovement EnemyMovement;
        IEnemySprintDeterminant EnemySprintDeterminant;

        protected override Vector2 MoveDirection { get => moveDirection; }
        protected override float SprintSpeed { get; set; }
        protected override float MoveSpeed { get; set; }
        protected override float SpeedChangeRate { get; set; }
        protected override float InputMagnitude { get; set; }
        protected override bool Sprint { get => sprint; }

        Transform targetTransform;

        Vector3 moveDistanse;
        Vector2 moveDirection;

        bool sprint;

        protected override void Awake()
        {
            base.Awake();

            LocalEnemyData = GetComponentInParent<ILocalEnemyData>();
            EnemyMovement = GetComponentInParent<IEnemyMovement>();
            EnemySprintDeterminant = GetComponent<IEnemySprintDeterminant>();
        }

        void Start()
        {
            SprintSpeed = LocalEnemyData.MutantData.SprintSpeed;
            MoveSpeed = LocalEnemyData.MutantData.MoveSpeed;
            SpeedChangeRate = LocalEnemyData.MutantData.SpeedChangeRate;
            InputMagnitude = 1;

            targetTransform = LocalEnemyData.TargetTransform;
            rotationSmoothTime = LocalEnemyData.MutantData.RotationSmoothTime;
        }

        public override void Execute()
        {
            if (LocalEnemyData.MutantData.ActiveState)
            {
                GetDirectionAndDistance();
                sprint = EnemySprintDeterminant.IsSprinting();
            }
            else
            {
                GetIdleDirectionAndDistance();
                sprint = false;
            }

            base.Execute();

            EnemyMovement.Move(moveDistanse, speed, rotationSmoothTime);
        }

        public override void Exit()
        {
            base.Exit();

            GetIdleDirectionAndDistance();
            EnemyMovement.Move(moveDistanse, speed, rotationSmoothTime);
        }

        void GetDirectionAndDistance()
        {
            moveDistanse = targetTransform.position - transform.position;
            moveDirection.x = moveDistanse.x;
            moveDirection.y = moveDistanse.z;
            moveDirection = MoveDirection.normalized;
        }

        void GetIdleDirectionAndDistance()
        {
            moveDistanse = targetTransform.position - transform.position;
            moveDirection = Vector2.zero;
        }
    }
}