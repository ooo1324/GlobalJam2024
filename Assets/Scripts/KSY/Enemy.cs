using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class Enemy : MonoBehaviour
    {
        private float moveSpeed;

        // ��� Ŭ�� Ƚ��
        private float hp;

        // end�� ����, �����Ҷ� ������ ������
        private float damage;

        private int moveIdx;

        // �̵� ����Ʈ
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
            // Waypoint ���� �������� �� ó��
            if (moveIdx == wayPointPos.Length)
                return;

            transform.position = Vector2.MoveTowards(transform.position, wayPointPos[moveIdx], MoveSpeed * Time.deltaTime);

            if (transform.position == wayPointPos[moveIdx])
                moveIdx++;
        }


        private void OnMouseDown()
        {
            //TODO : ������ �� ���⿡ ���� hp ���� �ǵ��� ����
            Poolable poolable = gameObject.GetComponent<Poolable>();
            Managers.Pool.Push(poolable);
            gameObject.SetActive(false);
        }

        
    } 
}
