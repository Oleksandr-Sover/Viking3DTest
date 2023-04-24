using UnityEngine;

namespace GameLogic
{
    public class AnimationIDsSetter : MonoBehaviour
    {
        public static int animIDSpeed;
        public static int animIDMotionSpeed;
        public static int animIDAttack;
        public static int animIDDamage;
        public static int animIDDie;
        public static int animIDAttackAchieved;

        void Start()
        {
            animIDSpeed = Animator.StringToHash("Speed");
            animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
            animIDAttack = Animator.StringToHash("Attack");
            animIDDamage = Animator.StringToHash("Damage");
            animIDDie = Animator.StringToHash("Die");
            animIDAttackAchieved = Animator.StringToHash("AttackAchieved");
        }
    }
}