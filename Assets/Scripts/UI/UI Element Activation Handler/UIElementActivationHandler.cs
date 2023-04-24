using UnityEngine;

namespace UI
{
    public class UIElementActivationHandler : MonoBehaviour
    {
        ILocalUIData LocalUIData;
        IUIElementsEnabler UIElementsEnabler;

        float endGameMenuTimer;

        bool isEndGameMenu;

        void Awake()
        {
            LocalUIData = GetComponentInChildren<ILocalUIData>();
            UIElementsEnabler = GetComponent<IUIElementsEnabler>();
        }

        void Start()
        {
            UIElementsEnabler.EnableInGame();
            endGameMenuTimer = LocalUIData.EndGameMenuTimer;
        }

        void Update()
        {
            EnableEndGameMenu();
        }

        void EnableEndGameMenu()
        {
            if (LocalUIData.PlayerCurrentHealth <= 0&& !isEndGameMenu)
            {
                if (endGameMenuTimer > 0)
                    endGameMenuTimer -= Time.deltaTime;
                else
                {
                    UIElementsEnabler.EnebleEndGameMenu();
                    LocalUIData.CursorLocked = false;
                    LocalUIData.CursorInputForLook = false;
                    Cursor.lockState = CursorLockMode.None;
                    isEndGameMenu = true;
                }
            }            
        }
    }
}