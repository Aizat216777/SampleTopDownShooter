using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class EnemySpawner : MonoBehaviourBase
    {
        private EnemySpawnData m_EnemySpawnData;
        [SerializeField]
        private EnemyController m_EnemyPrefab;
        private float m_DelayToSpawn;
        private float m_DelayToSpawnNow;
        private float m_DelayToUpdateDelayToSpawn;
        // Start is called before the first frame update
        void Start()
        {
            m_EnemySpawnData = ServiceLocator.Resolve<GameConfig>().enemySpawnData;
            m_DelayToSpawn = m_EnemySpawnData.spawnDelayMax;
            m_DelayToUpdateDelayToSpawn = m_EnemySpawnData.delayToUpdateSpawnDelay;
            m_DelayToSpawnNow = m_DelayToSpawn;
        }
        private void OnEnable()
        {
            IGameManager gameManager = ServiceLocator.Resolve<IGameManager>();
            if (gameManager != null)
            {
                gameManager.OnGameOver += GameOverCallback;
            }
        }
        private void OnDisable()
        {
            IGameManager gameManager = ServiceLocator.Resolve<IGameManager>();
            if (gameManager != null)
            {
                gameManager.OnGameOver -= GameOverCallback;
            }
        }
        // Update is called once per frame
        void Update()
        {
            m_DelayToSpawnNow -= Time.deltaTime;
            if (m_DelayToSpawnNow < 0)
            {
                m_DelayToSpawnNow = m_DelayToSpawn;
                SpawnNewEnemy();
            }
            m_DelayToUpdateDelayToSpawn -= Time.deltaTime;
            if (m_DelayToUpdateDelayToSpawn < 0)
            {
                m_DelayToUpdateDelayToSpawn = m_EnemySpawnData.delayToUpdateSpawnDelay;
                m_DelayToSpawn -= m_EnemySpawnData.spawnDelayStep;
                m_DelayToSpawn = Mathf.Max(m_DelayToSpawn, m_EnemySpawnData.spawnDelayMin);
            }
        }
        private void GameOverCallback()
        {
            enabled = false;
        }
        private void SpawnNewEnemy()
        {
            float offset = 1;
            Camera camera = ServiceLocator.Resolve<CameraMain>().camera;
            float orthSizeWidth = camera.orthographicSize * (((float)Screen.width) / Screen.height);
            Vector3 enemyPosition = camera.transform.position;
            if (Random.value > 0.5f)
            {
                enemyPosition.x += (Random.value > 0.5f ? 1.0f : -1.0f) * (orthSizeWidth + offset);
                enemyPosition.y += (-camera.orthographicSize) + camera.orthographicSize * 2.0f * Random.value;
            }
            else
            {
                enemyPosition.x += (-orthSizeWidth)  + orthSizeWidth * 2.0f * Random.value;
                enemyPosition.y += (Random.value > 0.5f ? 1.0f : -1.0f) * (camera.orthographicSize + offset);
            }
            EnemyController enemyController = Instantiate(
                m_EnemyPrefab,
                enemyPosition,
                Quaternion.identity,
                ServiceLocator.Resolve<ILevel>().Root);
            enemyController.Init(m_EnemySpawnData.GetRandomEnemyDataWithChances());
        }
    }
}