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
        

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            while (true)
            {
                Managers.Pool.Pop(spawnPrefab, gameObject.transform);

                yield return new WaitForSeconds(spawnRate);
            }      
        }
    }

}