using UnityEngine;

namespace GameLogic
{
    public class AnimationEvents : MonoBehaviour, IAnimationEvents
    {
        public bool StartOfAttack { get; private set; }
        public bool DefeatByAttack { get; private set; }
        public bool EndOfAttack { get; private set; }
        public bool StartOfDefeat { get; private set; }
        public bool EndOfDefeat { get; private set; }
        public bool Fell { get; private set; }

        void OnEnable()
        {
            Fell = false;
        }

        public void OnStartOfAttack()
        {
            StartOfAttack = true;
            DefeatByAttack = false; 
            EndOfAttack = false;

            StartOfDefeat = false;
            EndOfDefeat = false;
        }

        public void OnDefeatByAttack()
        {
            DefeatByAttack = true;
        }
        
        public void OnEndOfAttack()
        {
            StartOfAttack = false;
            DefeatByAttack = false;
            EndOfAttack = true;

            StartOfDefeat = false;
            EndOfDefeat = false;
        }

        public void OnStartOfDefeat()
        {
            StartOfDefeat = true;
            EndOfDefeat = false;

            StartOfAttack = false;
            DefeatByAttack = false;
            EndOfAttack = false;
        }

        public void OnEndOfDefeat()
        {
            StartOfDefeat = false;
            EndOfDefeat = true;

            StartOfAttack = false;
            DefeatByAttack = false;
            EndOfAttack = false;
        }

        public void OnFell()
        {
            Fell = true;
        }
    }
}