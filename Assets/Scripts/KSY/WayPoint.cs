using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField]
        public Vector3[] wayPointPos;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            for (int i = 0; i < wayPointPos.Length; i++)
            {
                Gizmos.DrawCube(wayPointPos[i], Vector3.one);
            }
       
        }
    } 
}
