using UnityEngine;

namespace UI
{
    public class LocalUIDataSetter : MonoBehaviour
    {
        [SerializeField] Data.UIData uIData;
        [SerializeField] Data.GlobalData globalData;
        [SerializeField] Data.PlayerData playerData;

        ILocalUIDataForSetter LocalUIDataForSetter;

        void Awake()
        {
            LocalUIDataForSetter = GetComponent<ILocalUIDataForSetter>();

            LocalUIDataForSetter.LocalPlayerData = GameObject.FindGameObjectWithTag("Player").GetComponent<GameLogic.ILocalPlayerData>();
            LocalUIDataForSetter.PlayerStartHealth = playerData.Health;
            LocalUIDataForSetter.GlobalData = globalData;
            LocalUIDataForSetter.EndGameMenuTimer = uIData.EndGameMenuTimer;
            LocalUIDataForSetter.PlayerData = playerData;
        }
    }
}