using UnityEngine;

namespace GameLogic
{
    public class EnemySprintDeterminant : MonoBehaviour, IEnemySprintDeterminant
    {
        ILocalEnemyData LocalEnemyData;

        float timer;
        float maxSprintTime;
        float minSprintTime;
        float maxWalkTime;
        float minWalkTime;
        float maxChanceOfSprinting = 0.4f;

        bool sprint;

        void Awake()
        {
            LocalEnemyData = GetComponentInParent<ILocalEnemyData>();
        }

        void Start ()
        {
            maxSprintTime = LocalEnemyData.MutantData.MaxSprintTime;
            minSprintTime = LocalEnemyData.MutantData.MinSprintTime;
            maxWalkTime = LocalEnemyData.MutantData.MaxWalkTime;
            minWalkTime = LocalEnemyData.MutantData.MinWalkTime;
            maxChanceOfSprinting = LocalEnemyData.MutantData.MaxChanceOfSprinting;
        }

        public bool IsSprinting()
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
            {
                sprint = IsSprint();

                if (sprint)
                    timer = Random.Range(minSprintTime, maxSprintTime);
                else
                    timer = Random.Range(minWalkTime, maxWalkTime);
            }
            return sprint;
        }

        bool IsSprint()
        {
            float value = Random.value;

            if (value < maxChanceOfSprinting)
                return true;
            else
                return false;
        }
    }
}