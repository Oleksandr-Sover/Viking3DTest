using UnityEngine;

namespace UI
{
    public class UIElementsEnabler : MonoBehaviour, IUIElementsEnabler
    {
        [SerializeField] GameObject[] elementsInGame = new GameObject[0];
        [SerializeField] GameObject[] elementsInEndGameMenu = new GameObject[0];

        public void EnableInGame()
        {
            EnableUIElements(elementsInGame);
            DisableUIElements(elementsInEndGameMenu);
        }

        public void EnebleEndGameMenu()
        {
            EnableUIElements(elementsInEndGameMenu);
            DisableUIElements(elementsInGame);
        }

        void EnableUIElements(GameObject[] elements)
        {
            foreach (GameObject element in elements) element.SetActive(true);
        }

        void DisableUIElements(GameObject[] elements)
        {
            foreach (GameObject element in elements) element.SetActive(false);
        }
    }
}