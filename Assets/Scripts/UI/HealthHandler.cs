using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthHandler : MonoBehaviour
    {
        ILocalUIData LocalUIData;

        Slider healthSlider;

        int health;

        void Awake()
        {
            LocalUIData = GetComponentInParent<ILocalUIData>();
            healthSlider = GetComponent<Slider>();
        }

        void Start()
        {
            health = LocalUIData.PlayerStartHealth;
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }

        void Update()
        {
            if (health != LocalUIData.PlayerCurrentHealth)
            {
                health = LocalUIData.PlayerCurrentHealth;
                healthSlider.value = health;
            }
        }
    }
}