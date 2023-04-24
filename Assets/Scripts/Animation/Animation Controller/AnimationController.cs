using UnityEngine;

namespace GameLogic
{
    public class AnimationController : MonoBehaviour, IAnimationController
    {
        Animator animator;

        float animationBlend;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void AnimateMotion(float speed, float inputMagnitude, float speedChangeRate)
        {
            animationBlend = Mathf.Lerp(animationBlend, speed, Time.deltaTime * speedChangeRate);

            if (animationBlend < 0.01f)
                animationBlend = 0f;
            
            animator.SetFloat(AnimationIDsSetter.animIDSpeed, animationBlend);
            animator.SetFloat(AnimationIDsSetter.animIDMotionSpeed, inputMagnitude);
        }

        public void SlowDownMotion(float speedChangeRate)
        {
            animationBlend = Mathf.Lerp(animationBlend, 0, Time.deltaTime * speedChangeRate); ;

            animator.SetFloat(AnimationIDsSetter.animIDSpeed, animationBlend);
            animator.SetFloat(AnimationIDsSetter.animIDMotionSpeed, 0);
        }

        public void AnimateAttack(bool isAttack) => animator.SetBool(AnimationIDsSetter.animIDAttack, isAttack);

        public void AnimateDamage(bool isDamage) => animator.SetBool(AnimationIDsSetter.animIDDamage, isDamage);

        public void AnimateDie(bool isDie) => animator.SetBool(AnimationIDsSetter.animIDDie, isDie);

        public void AttackAchieved(bool isAchieved) => animator.SetBool(AnimationIDsSetter.animIDAttackAchieved, isAchieved);
    }
}