using UnityEngine;

namespace UI
{
    public class LocalUIData : MonoBehaviour, ILocalUIData, ILocalUIDataForSetter
    {
        public Data.GlobalData GlobalData { get; set; }
        public Data.PlayerData PlayerData { get; set; }
        public GameLogic.ILocalPlayerData LocalPlayerData { get; set; }
        public int PlayerStartHealth { get; set; }
        public int PlayerCurrentHealth { get => LocalPlayerData.Health; }
        public int Score { get => GlobalData.Score; }
        public float EndGameMenuTimer { get; set; }
        public bool CursorLocked { get => PlayerData.CursorLocked; set => PlayerData.CursorLocked = value; }
        public bool CursorInputForLook { get => PlayerData.CursorInputForLook; set => PlayerData.CursorInputForLook = value; }
    }
}