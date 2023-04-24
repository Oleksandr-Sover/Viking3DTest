using UnityEngine;

namespace GameLogic
{
    public class StartDataSetter : MonoBehaviour
    {
        [SerializeField] Data.GlobalData globalData;
        [SerializeField] Data.PlayerData playerData;

        void Awake()
        {
            globalData.Score = 0;
            playerData.CursorInputForLook = true;
            playerData.CursorLocked = true;
        }
    }
}