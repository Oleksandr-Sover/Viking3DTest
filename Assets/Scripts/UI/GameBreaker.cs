using UnityEngine;

namespace UI
{
    public class GameBreaker : MonoBehaviour
    {
        public void QuitGame()
        {
#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}