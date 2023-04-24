
namespace GameLogic
{
    public interface IAnimationController
    {
        void AnimateMotion(float speed, float inputMagnitude, float speedChangeRate);
        void SlowDownMotion(float speedChangeRate);
        void AnimateAttack(bool isAttack);
        void AnimateDamage(bool isDamage);
        void AnimateDie(bool isDie);
        void AttackAchieved(bool isAchieved);
    }
}