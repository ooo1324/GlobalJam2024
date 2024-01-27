using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class Enemy : MonoBehaviour
    {

        private float moveSpeed;

        // ��� Ŭ�� Ƚ��
        private int clickHp;

        // end�� ����, �����Ҷ� ������ ������
        private float damage;

        private SpriteRenderer spriteRender;

        [SerializeField]
        private int moveIdx;
        public int MoveIdx
        {
            get { return moveIdx; }
            set
            {
                moveIdx = value;
            }
        }

        [SerializeField]
        private EEnemyType enemyType;
        
        public EEnemyType EnemyType
        {
            get { return enemyType; }
            set
            {
                enemyType = value;
            }
        }

        private Vector3[] wayPointPos;
        // �̵� ����Ʈ
        public Vector3[] WayPointPos
        {
            get { return wayPointPos; }
            set
            {
                wayPointPos = value;
            }
        }

        [SerializeField]
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

        public void Start()
        {
            //TestData
            moveSpeed = 14;
            spriteRender = gameObject.GetComponent<SpriteRenderer>();
            Init();
        }

        public void Init()
        {
            spawnerIdx = -1;
            moveIdx = 0;
        }
        void Update()
        {
            MovePath();
            ChildUpdate();
        }

        void MovePath()
        {
            // Waypoint ���� �������� �� ó��
            if (moveIdx == wayPointPos.Length)
                return;
            spriteRender.flipX = (transform.position.x - wayPointPos[moveIdx].x) < 0;
            transform.position = Vector2.MoveTowards(transform.position, wayPointPos[moveIdx], MoveSpeed * Time.deltaTime);

            if (transform.position == wayPointPos[moveIdx])
            {
                moveIdx++;
            }        
        }

        private void OnMouseDown()
        {
            //TODO : ������ �� ���⿡ ���� hp ���� �ǵ��� ����
            Managers.Events.MinusEnemyInvoke();
            GameManager.Instance.RemoveEnemyObj(gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("EndSensor"))
            {
                Managers.Events.MinusEnemyInvoke();
                GameManager.Instance.RemoveEnemyObj(gameObject);
            }
        }

        protected virtual void ChildUpdate() { }
    } 
}
