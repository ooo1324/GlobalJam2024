using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField]
        public Vector3[] wayPointPos;

        [SerializeField]
        private Color gizmoColor;

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;

            for (int i = 0; i < wayPointPos.Length; i++)
            {
                Gizmos.DrawCube(wayPointPos[i], Vector3.one);
            }
       
        }
    } 
}
