using UnityEngine;

namespace GameLogic
{
    public interface ILocalEnemyDataForSetter
    {
        Data.MutantData MutantData { get; set; }
        IEnemyFactory MyFactory { get; set; }
        ILocalPlayerData LocalPlayerData { get; set; }
        IEnemyController EnemyController { get; set; }
        GameObject ThisGameObject { get; set; }
        CharacterController CharacterController { get; set; }
        Transform TargetTransform { get; set; }
        Transform ThisTransform { get; set; }
        int Health { get; set; }
    }
}