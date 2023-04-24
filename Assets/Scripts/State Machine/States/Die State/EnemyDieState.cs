using UnityEngine;

namespace GameLogic
{
    public class EnemyDieState : CharacterDieState
    {
        ILocalEnemyData LocalEnemyData;

        float timer;

        bool destroyed;

        protected override void Awake()
        {
            base.Awake();

            LocalEnemyData = GetComponentInParent<ILocalEnemyData>();

        }

        public override void Enter()
        {
            base.Enter();

            timer = LocalEnemyData.MutantData.DestructionTime;
            destroyed = false;
        }

        public override void Execute()
        {
            base.Execute();

            if (AnimationEvents.Fell)
                LocalEnemyData.CharacterController.enabled = false;

            DestroyYourselfInTime();
        }

        void DestroyYourselfInTime()
        {
            if (timer > 0 && !destroyed)
                timer -= Time.deltaTime;
            else if (!destroyed)
            {
                LocalEnemyData.MyFactory.Destroy(LocalEnemyData.ThisGameObject);
                destroyed = true;
            }
        }
    }
}