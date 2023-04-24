
namespace GameLogic
{
    public class CharacterDamageState : InterruptingState
    {
        public override void Enter()
        {
            base.Enter();

            AnimationController.AnimateDamage(true);
        }

        public override void Execute()
        {
            AnimationController.AnimateDamage(false);
        }

        public override void Exit()
        {
            base.Exit();

            AnimationController.AnimateDamage(false);
        }
    }
}