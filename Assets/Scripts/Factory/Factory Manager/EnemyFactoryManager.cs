using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public class EnemyFactoryManager : MonoBehaviour
    {
        [SerializeField] Data.GlobalData globalData;

        IEnemyFactory EnemyFactory;

        Transform playerTransform;

        LayerMask terrainLayer;

        RaycastHit hit;

        readonly WaitForSeconds waitSec = new (1);

        float distanceToPlayer;
        float startingAltitudeAboveGround;

        readonly int startingRayHeight = 100;
        int maxNumberOfEnemies;

        bool doesCoroutineWork;

        void Awake()
        {
            EnemyFactory = GetComponent<IEnemyFactory>();
        }

        void Start()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

            terrainLayer = globalData.TerrainLayer;
            maxNumberOfEnemies = globalData.MaxNumberOfEnemies;
            distanceToPlayer = globalData.DistanceToPlayer;
            startingAltitudeAboveGround = globalData.StartingAltitudeAboveGround;
        }

        void Update()
        {
            int activeEnemyCount = EnemyFactory.ActiveObjects.Count;

            if (activeEnemyCount < maxNumberOfEnemies && !doesCoroutineWork)
                StartCoroutine(SetEnemy());
        }

        IEnumerator SetEnemy()
        {
            doesCoroutineWork = true;

            Vector3 position = GetEnemyPosition();
            EnemyFactory.CreateEnemy(position);

            yield return waitSec;

            doesCoroutineWork = false;
        }

        Vector3 GetEnemyPosition()
        {
            float angle = Random.Range(0, 360);
            Vector3 position = playerTransform.forward * distanceToPlayer;

            position = Quaternion.Euler(0, angle, 0) * position;
            position.y = startingRayHeight;
            position += playerTransform.position;

            Ray ray = new (position, Vector3.down);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer))
                position = hit.point;
            else
                position = Vector3.zero;

            position.y += startingAltitudeAboveGround;

            return position;
        }
    }
}