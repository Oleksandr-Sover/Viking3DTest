
namespace GameLogic
{
    public interface IEnemyAttackDistanceHandler
    {
        bool TargetWasInAffectedArea { get; }
        bool TargetInAffectedArea();
    }
}