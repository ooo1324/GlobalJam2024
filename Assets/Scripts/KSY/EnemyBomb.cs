using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class EnemyBomb : Enemy
    {
        [SerializeField]
        private float minTime;

        [SerializeField]
        private float maxTime;


        private float bombTime;

        private float timeSec;


        // Start is called before the first frame update
        void Start()
        {
            
            StartCoroutine(CheckTime());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator CheckTime()
        {
            while (true)
            { 

            }
        }

        //protected override void ChildUpdate()
        //{
        //    Debug.Log("Child Update");
        //}
    }

}