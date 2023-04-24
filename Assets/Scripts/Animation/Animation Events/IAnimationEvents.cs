
namespace GameLogic
{
    public interface IAnimationEvents
    {
        bool StartOfAttack { get; }
        bool DefeatByAttack { get; }
        bool EndOfAttack { get; }
        bool StartOfDefeat { get; }
        bool EndOfDefeat { get; }
        bool Fell { get; }
    }
}