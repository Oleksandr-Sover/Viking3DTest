using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UIData", menuName = "Data/UIData", order = 4)]
    public class UIData : ScriptableObject
    {
        [Header("End Game Menu")]

        [SerializeField] float endGameMenuTimer = 5f;
        public float EndGameMenuTimer { get => endGameMenuTimer; }
    }
}