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
            enemy.SpawnerIdx++;
            int spawnerIdx = enemy.SpawnerIdx * 4;
            int ranIdx = Random.Range(spawnerIdx, spawnerIdx + 4);
            obj.transform.position = spawnPos[ranIdx].transform.position;
            enemy.wayPointPos = wayPoint[ranIdx].wayPointPos;
            obj.SetActive(true);          
        }
    }
}