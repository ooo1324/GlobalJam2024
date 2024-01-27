using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField]
        public float spawnRate;

        [SerializeField]
        private int rotateAngle;

        [SerializeField]
        private GameObject[] spawnPrefabs;

        [SerializeField]
        private GameObject[] spawnPos;

        [SerializeField]
        private GameObject bossSpawnPos;

        [SerializeField]
        private GameObject[] spawnBossPrefabs;

        [SerializeField]
        private int spawnMaxCnt;

        [SerializeField]
        private int spawnCurrCnt = 0;

        private List<WayPoint> wayPoint;


        void Awake()
        {
            wayPoint = new List<WayPoint>();
            for (int i = 0; i < spawnPos.Length; i++)
            {
                wayPoint.Add(spawnPos[i].GetComponent<WayPoint>());
            }       
        }

        public void StartSpawn(int cnt)
        {
            spawnCurrCnt = 0;
            spawnMaxCnt = cnt;
            StartCoroutine(Spawn());
        }

        public void StopSpawn()
        {
            StopCoroutine(Spawn());
        }

        public void BossSpawn(int bossIdx)
        {
            Poolable obj = Managers.Pool.Pop(spawnBossPrefabs[bossIdx], gameObject.transform);
            Managers.Events.AddEnemyInvoke();
            Enemy enemy = obj.gameObject.GetComponent<Enemy>();
            enemy.WayPointPos = bossSpawnPos.GetComponent<WayPoint>().wayPointPos;
            obj.gameObject.transform.position = bossSpawnPos.transform.position;
            enemy.Init();
        }

        IEnumerator Spawn()
        {
            while (spawnCurrCnt < spawnMaxCnt)
            {
                int randIdx = UnityEngine.Random.Range(0, spawnPos.Length);
                int randSpawnIdx = UnityEngine.Random.Range(0, spawnPrefabs.Length);
                Poolable obj = Managers.Pool.Pop(spawnPrefabs[randSpawnIdx], gameObject.transform);
                
                Enemy enemy = obj.gameObject.GetComponent<Enemy>();

                enemy.WayPointPos = wayPoint[randIdx].wayPointPos;
                obj.gameObject.transform.position = spawnPos[randIdx].transform.position;
                if (enemy.EnemyType == EEnemyType.TeddyBear_Bomb)
                {
                    EnemyBomb enemyBomb = obj.gameObject.GetComponent<EnemyBomb>();
                    enemyBomb.StartBomb();
                }

                enemy.Init();
                Managers.Events.AddEnemyInvoke();
                spawnCurrCnt++;

                yield return new WaitForSeconds(spawnRate);
            }

            GameManager.Instance.WaveTimeStart();
        }
    }
}