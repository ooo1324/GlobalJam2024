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

        IEnumerator Spawn()
        {
            while (spawnCurrCnt < spawnMaxCnt)
            {
                int randIdx = UnityEngine.Random.Range(0, spawnPos.Length);
                int randSpawnIdx = UnityEngine.Random.Range(0, spawnPrefabs.Length);
                Poolable obj = Managers.Pool.Pop(spawnPrefabs[randSpawnIdx], gameObject.transform);
                Enemy enemy = obj.gameObject.GetComponent<Enemy>();
                enemy.wayPointPos = wayPoint[randIdx].wayPointPos;
                enemy.Init();
                obj.gameObject.transform.position = spawnPos[randIdx].transform.position;
                Managers.Events.AddEnemyInvoke();
                spawnCurrCnt++;

                yield return new WaitForSeconds(spawnRate);
            }

            GameManager.Instance.WaveTimeStart();
        }
    }
}