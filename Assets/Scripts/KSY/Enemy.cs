using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class Enemy : MonoBehaviour
    {
        private float moveSpeed;

        // 사망 클릭 횟수
        private float hp;

        // end에 도달, 자폭할때 입히는 데미지
        private float damage;

        private int moveIdx;

        // 이동 포인트
        public Vector3[] wayPointPos;

        private int spawnerIdx;
        public int SpawnerIdx
        {
            get { return spawnerIdx; }
            set
            {
                spawnerIdx = value;
            }
        }


        [SerializeField]
        public float MoveSpeed
        {
            get { return moveSpeed; }
            set
            {
                moveSpeed = value;
            }
        }

        void Start()
        {
            //TestData
            spawnerIdx = -1;
            moveSpeed = 3;
            moveIdx = 0;
        }

        void Update()
        {
            MovePath();
        }

        void MovePath()
        {
            // Waypoint 끝에 도달했을 때 처리
            if (moveIdx == wayPointPos.Length)
                return;

            transform.position = Vector2.MoveTowards(transform.position, wayPointPos[moveIdx], MoveSpeed * Time.deltaTime);

            if (transform.position == wayPointPos[moveIdx])
                moveIdx++;
        }


        private void OnMouseDown()
        {
            //TODO : 눌렀을 때 무기에 따라 hp 감소 되도록 수정
            Poolable poolable = gameObject.GetComponent<Poolable>();
            Managers.Pool.Push(poolable);
            gameObject.SetActive(false);
        }

        
    } 
}
