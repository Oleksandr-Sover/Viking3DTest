using UnityEngine;

namespace GameLogic
{
    public abstract class CharactersController : MonoBehaviour
    {
        protected IInterruptStateDeterminer InterruptStateDeterminer;

        protected readonly IStateInitializer StateInitializer = new StateInitializer();

        protected IState CurrentState;

        protected abstract IState MoveState { get; }
        protected abstract IState AttackState { get; }
        protected abstract IState DamageState { get; }
        protected abstract IState DieState { get; }

        protected abstract int Health { get; }
        protected abstract bool Attack { get; }

        protected readonly IDamageHandler DamageHandler = new DamageHandler();

        protected bool inAnInterrupt;
        bool damage;

        protected virtual void Awake()
        {
            InterruptStateDeterminer = GetComponentInChildren<IInterruptStateDeterminer>();
        }

        protected virtual void Start()
        {
            CurrentState = StateInitializer.NewState(MoveState);
            DamageHandler.SetStartHealth(Health);            
        }

        protected virtual void Update()
        {
            damage = DamageHandler.DidGetDamage(Health);
            inAnInterrupt = InterruptStateDeterminer.DefineInterruptionState();

            if (Health <= 0)
            {
                if (!DieState.IsInState)
                    CurrentState = StateInitializer.ChangeState(DieState);
                else
                    CurrentState.Execute();
            }
            else if (Health > 0)
            {
                if (damage)
                    CurrentState = StateInitializer.ChangeState(DamageState);

                else if (Attack && !AttackState.IsInState)
                    CurrentState = StateInitializer.ChangeState(AttackState);

                else if (!MoveState.IsInState && !inAnInterrupt)
                    CurrentState = StateInitializer.ChangeState(MoveState);

                else if (MoveState.IsInState && !inAnInterrupt)
                    CurrentState.Execute();

                else if (!MoveState.IsInState && inAnInterrupt)
                    CurrentState.Execute();
            }
        }
    }
}