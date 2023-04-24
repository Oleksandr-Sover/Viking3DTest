using UnityEngine;

namespace GameLogic
{
    public abstract class CharacterAttackState : InterruptingState
    {
        ICharacterRotator CharacterRotator;

        protected abstract Vector2 RotateDirection { get; }
        protected abstract float SpeedChangeRate { get; set; }

        protected float rotationSmoothTime;

        protected bool attackAchieved;
        protected bool damageIsDone;

        protected override void Awake()
        {
            base.Awake();

            CharacterRotator = GetComponentInParent<ICharacterRotator>();
        }

        public override void Enter()
        {
            base.Enter();

            AnimationController.AnimateAttack(true);
            damageIsDone = false;
        }

        public override void Execute()
        {
            AnimationController.SlowDownMotion(SpeedChangeRate);

            attackAchieved = AnimationEvents.DefeatByAttack;
            AnimationController.AttackAchieved(attackAchieved);

            if (attackAchieved)
                AnimationController.AnimateDamage(false);

            CharacterRotator.Rotate(RotateDirection.x, RotateDirection.y, rotationSmoothTime);
        }

        public override void Exit()
        {
            base.Exit();

            AnimationController.AttackAchieved(false);
            AnimationController.AnimateAttack(false);
        }
    }
}