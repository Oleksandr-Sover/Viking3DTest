
namespace GameLogic
{
    public class EnemyController : CharactersController, IEnemyController
    {
        ILocalEnemyData LocalEnemyData;
        IEnemyAttackDistanceHandler EnemyAttackDistanceHandler;

        EnemyMoveState enemyMoveState;
        EnemyAttackState enemyAttackState;
        CharacterDamageState enemyDamageState;
        CharacterDieState enemyDieState;

        protected override IState MoveState { get => enemyMoveState; }
        protected override IState AttackState { get => enemyAttackState; }
        protected override IState DamageState { get => enemyDamageState; }
        protected override IState DieState { get => enemyDieState; }

        protected override int Health { get => LocalEnemyData.Health; }
        protected override bool Attack { get => attack; }

        bool attack;

        protected override void Awake()
        {
            base.Awake();

            LocalEnemyData = GetComponent<ILocalEnemyData>();
            EnemyAttackDistanceHandler = GetComponentInChildren<IEnemyAttackDistanceHandler>();

            enemyMoveState = GetComponentInChildren<EnemyMoveState>();
            enemyAttackState = GetComponentInChildren<EnemyAttackState>();
            enemyDamageState = GetComponentInChildren<CharacterDamageState>();
            enemyDieState = GetComponentInChildren<CharacterDieState>();
        }

        protected override void Update()
        {
            if (LocalEnemyData.MutantData.ActiveState)
            {
                if (EnemyAttackDistanceHandler.TargetWasInAffectedArea)
                    attack = true;
                else
                    attack = false;

                base.Update();
            }
            else if (!MoveState.IsInState)
                CurrentState = StateInitializer.ChangeState(MoveState);
            else
                CurrentState.Execute();
        }

        public void SetStartHealthForDamageHandler() => DamageHandler.SetStartHealth(Health);
    }
}