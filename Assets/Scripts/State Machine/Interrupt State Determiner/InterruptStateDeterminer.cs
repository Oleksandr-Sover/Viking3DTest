using UnityEngine;

namespace GameLogic
{
    public class InterruptStateDeterminer : MonoBehaviour, IInterruptStateDeterminer
    {
        IAnimationEvents AnimationEvents;

        void Awake()
        {
            AnimationEvents = GetComponentInParent<IAnimationEvents>();
        }

        public bool DefineInterruptionState()
        {
            if (AnimationEvents.StartOfAttack || AnimationEvents.StartOfDefeat)
                return true;
            else
                return false;
        }
    }
}