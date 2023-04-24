using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public class EnemyActivityHandler : MonoBehaviour
    {
        [SerializeField] Data.MutantData mutantData;
        [SerializeField] ILocalPlayerData LocalPlayerData;

        readonly WaitForSeconds waitSec = new (1);

        [SerializeField] bool activateEnemies = true;

        bool doesCoroutineWork = false;

        void Awake()
        {
            LocalPlayerData = GameObject.FindGameObjectWithTag("Player").GetComponent<ILocalPlayerData>();
        }

        void Start()
        {
            mutantData.ActiveState = false;
        }

        void Update()
        {
            if (!doesCoroutineWork && activateEnemies)
                StartCoroutine(IsPlayerAlive());
        }

        IEnumerator IsPlayerAlive()
        {
            doesCoroutineWork = true;

            if (LocalPlayerData.Health > 0)
                mutantData.ActiveState = true;
            else
                mutantData.ActiveState = false;

            yield return waitSec;

            doesCoroutineWork = false;
        }
    }
}