using UnityEngine;

namespace GameLogic
{
    public abstract class CharacterMoveState : CharacterState
    {
        ISpeedController SpeedController;

        protected abstract Vector2 MoveDirection { get; }
        protected abstract float SprintSpeed { get; set; }
        protected abstract float MoveSpeed { get; set; }
        protected abstract float SpeedChangeRate { get; set; }
        protected abstract float InputMagnitude { get; set; }
        protected abstract bool Sprint { get; }

        protected float rotationSmoothTime;
        protected float speed;

        protected override void Awake()
        {
            base.Awake();

            SpeedController = GetComponentInParent<ISpeedController>();
        }

        public override void Execute()
        {
            speed = SpeedController.GetSpeed(MoveDirection, InputMagnitude, SprintSpeed, MoveSpeed, SpeedChangeRate, Sprint);
            AnimationController.AnimateMotion(speed, InputMagnitude, SpeedChangeRate);
        }
    }
}