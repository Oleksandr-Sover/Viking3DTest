using UnityEngine;

namespace GameLogic
{
    public interface ILocalEnemyData
    {
        Data.MutantData MutantData { get; }
        IEnemyFactory MyFactory { get; }
        IEnemyController EnemyController { get; }
        GameObject ThisGameObject { get; }
        CharacterController CharacterController { get; }
        Transform TargetTransform { get; }
        Transform ThisTransform { get; }
        int Health { get; set; }
        int TargetHealth { get; set; }
    }
}