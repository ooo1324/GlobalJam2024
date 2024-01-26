using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class Enemy : MonoBehaviour
    {
        private float moveSpeed;


        [SerializeField]
        public float MoveSpeed
        {
            get { return moveSpeed; }
            set
            {
                moveSpeed = value;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            //TestData
            moveSpeed = 3;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        private void OnMouseDown()
        {
            gameObject.SetActive(false);
        }
    } 
}
