
namespace GameLogic
{
    public class CharacterDieState : CharacterState
    {
        protected IAnimationEvents AnimationEvents;

        protected override void Awake()
        {
            base.Awake();

            AnimationEvents = GetComponentInParent<AnimationEvents>();
        }

        public override void Enter()
        {
            base.Enter();
            
            AnimationController.AnimateDamage(true);
        }

        public override void Execute()
        {
            AnimationController.AnimateDie(true);
            AnimationController.AnimateDamage(false);
        }
    }
}