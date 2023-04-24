using UnityEngine;

namespace GameLogic
{
    public abstract class CharacterState : MonoBehaviour, IState
    {
        protected IAnimationController AnimationController;

        public bool IsInState { get; private set; }
        public virtual void Enter() => IsInState = true;
        public virtual void Exit() => IsInState = false;
        public abstract void Execute();

        protected virtual void Awake()
        {
            AnimationController = GetComponentInParent<IAnimationController>();
        }
    }
}