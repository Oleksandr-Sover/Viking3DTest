
namespace GameLogic
{
    public interface IStateInitializer
    {
        IState NewState(IState newState);
        IState ChangeState(IState nextState);
    }
}