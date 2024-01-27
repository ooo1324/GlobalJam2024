using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class RoadSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] spawnPos;

        private List<WayPoint> wayPoint;

        [SerializeField]
        private GameObject[] bossSpawnPos;


        void Awake()
        {
            wayPoint = new List<WayPoint>();
            for (int i = 0; i < spawnPos.Length; i++)
            {
                wayPoint.Add(spawnPos[i].GetComponent<WayPoint>());
            }
        }


        public void RoadSpawn(GameObject obj)
        {
            Enemy enemy = obj.GetComponent<Enemy>();
            if (enemy.SpawnerIdx >= 2)
                return;
            enemy.SpawnerIdx++;

            if (enemy.EnemyType == EEnemyType.Clown_Boss)
            {         
                int ranIdx = Random.Range(0, 4);
                obj.transform.position = bossSpawnPos[enemy.SpawnerIdx].transform.position;
                enemy.WayPointPos = bossSpawnPos[enemy.SpawnerIdx].GetComponent<WayPoint>().wayPointPos;
                enemy.MoveIdx = 0;
            }
            else
            {
                int spawnerIdx = enemy.SpawnerIdx * 4;
                int ranIdx = Random.Range(spawnerIdx, spawnerIdx + 4);
                obj.transform.position = spawnPos[ranIdx].transform.position;
                enemy.WayPointPos = wayPoint[ranIdx].wayPointPos;
                enemy.MoveIdx = 0;
            }
       
            obj.SetActive(true);
        }
    }
}