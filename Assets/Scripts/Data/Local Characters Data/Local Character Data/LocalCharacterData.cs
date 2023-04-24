using UnityEngine;

namespace GameLogic
{
    public class LocalCharacterData : MonoBehaviour, ILocalCharacterData
    {
        public Data.GlobalData GlobalData { get => globalData; }
        [SerializeField] Data.GlobalData globalData;
    }
}