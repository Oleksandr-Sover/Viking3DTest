
namespace GameLogic
{
    public interface IState
    {
        bool IsInState { get; }
        void Enter();
        void Execute();
        void Exit();
    }
}