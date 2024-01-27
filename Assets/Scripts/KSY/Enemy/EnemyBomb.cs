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

        [SerializeField]
        private float bombTime;

        [SerializeField]
        private float timeSec;

        private Animator anim;

        public void StartBomb()
        {
            anim = GetComponent<Animator>();
            timeSec = 0;
            bombTime = Random.Range(minTime, maxTime);
            StartCoroutine(CheckTime());
        }

        IEnumerator CheckTime()
        {
            while (timeSec < bombTime)
            {
                timeSec += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }

            anim.SetBool("isBomb", true); 
        }

        public void Bomb()
        {
            // 터지는거 처리
            Debug.Log("Bomb!");
            // 애니메이션 수행 애니메이션 이벤트 받아서 터지도록 구현
            Managers.Events.MinusScoreInvoke();
            GameManager.Instance.RemoveEnemyObj(gameObject);
        }
    }

}