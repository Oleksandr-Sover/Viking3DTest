using UnityEngine;

namespace UI
{
    public class CameraSetter : MonoBehaviour
    {
        [SerializeField] Camera cam;

        Canvas canvas;

        void Awake()
        {
            canvas = GetComponent<Canvas>();
            canvas.worldCamera = cam;
        }
    }
}