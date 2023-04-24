
namespace GameLogic
{
    public class StateInitializer : IStateInitializer
    {
        IState CurrentState;

        public IState NewState(IState newState)
        {
            newState?.Enter();
            CurrentState = newState;
            return newState;
        }

        public IState ChangeState(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState?.Enter();
            return nextState;
        }
    }
}