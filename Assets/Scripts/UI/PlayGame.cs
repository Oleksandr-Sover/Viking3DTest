using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PlayGame : MonoBehaviour
    {
        public void OnPlayGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}