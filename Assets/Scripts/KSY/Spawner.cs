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

        private WayPoint wayPoint;


        void Start()
        {
            wayPoint = GetComponent<WayPoint>();
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            while (true)
            {
                Poolable obj = Managers.Pool.Pop(spawnPrefab, gameObject.transform);
                obj.gameObject.GetComponent<Enemy>().wayPointPos = wayPoint.wayPointPos;
                obj.gameObject.transform.position = gameObject.transform.position;
     

                yield return new WaitForSeconds(spawnRate);
            }      
        }

    }

}