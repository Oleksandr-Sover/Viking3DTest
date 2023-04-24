using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public abstract class InterruptingState : CharacterState
    {
        protected IAnimationEvents AnimationEvents;

        protected override void Awake()
        {
            base.Awake();

            AnimationEvents = GetComponentInParent<AnimationEvents>();
        }
    }
}