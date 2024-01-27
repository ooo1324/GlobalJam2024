using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField]
        private float spawnRate;

        [SerializeField]
        private int rotateAngle;

        [SerializeField]
        private GameObject spawnPrefab;

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
                int randIdx = Random.Range(0, spawnPos.Length);
                Poolable obj = Managers.Pool.Pop(spawnPrefab, spawnPos[randIdx].transform);
                obj.gameObject.GetComponent<Enemy>().wayPointPos = wayPoint[randIdx].wayPointPos;
                obj.gameObject.transform.position = spawnPos[randIdx].transform.position;
                GameManager.Instance.AddEnemyObj(obj.gameObject);

                spawnCurrCnt++;

                yield return new WaitForSeconds(spawnRate);
            }      
        }
    }
}