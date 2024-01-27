using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class Enemy : MonoBehaviour
    {

        private float moveSpeed;

        // 사망 클릭 횟수
        private int clickHp;

        // end에 도달, 자폭할때 입히는 데미지
        private float damage;

        private SpriteRenderer spriteRender;

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

        // 이동 포인트
        public Vector3[] wayPointPos;

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
            // Waypoint 끝에 도달했을 때 처리
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
            //TODO : 눌렀을 때 무기에 따라 hp 감소 되도록 수정
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
