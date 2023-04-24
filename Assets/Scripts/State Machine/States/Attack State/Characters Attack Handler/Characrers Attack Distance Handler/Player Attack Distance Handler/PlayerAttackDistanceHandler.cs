using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayerAttackDistanceHandler : MonoBehaviour, IPlayerAttackDistanceHandler
    {
        ILocalPlayerData LocalPlayerData;

        readonly List<GameObject> enemies = new ();
         
        public List<GameObject> EnemiesInAffectedArea { get => enemiesInAffectedArea; }
        readonly List<GameObject> enemiesInAffectedArea = new ();

        readonly List<GameObject> tempEnemiesInAffectedArea = new ();

        float sqrMaxDistance;

        int enemiesCount;

        bool isCoroutineWorks;

        void Awake()
        {
            LocalPlayerData = GetComponentInParent<ILocalPlayerData>();
        }

        void Start()
        {
            sqrMaxDistance = LocalPlayerData.PlayerData.AttackDistance * LocalPlayerData.PlayerData.AttackDistance;
        }

        void LateUpdate()
        {
            if (LocalPlayerData.Enemies != null)
            {
                enemiesCount = LocalPlayerData.Enemies.Count;

                if (enemiesCount > 0 && !isCoroutineWorks)
                    StartCoroutine(GetEnemiesInAffectedArea());
            }
        }

        IEnumerator GetEnemiesInAffectedArea()
        {
            isCoroutineWorks = true;

            enemies.Clear();
            enemies.AddRange(LocalPlayerData.Enemies);

            tempEnemiesInAffectedArea.Clear();

            yield return null;

            foreach (var enemy in enemies)
            {
                if (enemy != null)
                {
                    Vector3 enemyPosition = enemy.transform.position;
                    enemyPosition.y = transform.position.y;
                    float sqrDistance = (enemyPosition - transform.position).sqrMagnitude;

                    if (sqrDistance < sqrMaxDistance)
                        tempEnemiesInAffectedArea.Add(enemy);
                }
                yield return null;
            }

            enemiesInAffectedArea.Clear();
            enemiesInAffectedArea.AddRange(tempEnemiesInAffectedArea);

            yield return null;

            isCoroutineWorks = false;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;

            foreach (var enemy in EnemiesInAffectedArea)
            {
                Gizmos.DrawSphere(enemy.transform.position, 0.3f);
            }
        }
    }
}