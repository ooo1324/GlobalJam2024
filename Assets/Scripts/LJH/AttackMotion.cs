using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LJH{
    public class AttackMotion : MonoBehaviour
    {
        private Animator animator;
        [SerializeField] List<AnimationClip> clips = new();

        private void Start() {
            animator = GetComponent<Animator>();
            StartCoroutine(WaitForAnimationEnd());
        }

        IEnumerator WaitForAnimationEnd()
        {
            float length = 0f;
            switch(CursorManager.Instance.nowWeponNum){
                case 0 : //sword;
                    length = clips[0].length;
                break;
                case 1: //wand;
                    length = clips[1].length;
                break;
                case 2: //Gun
                    length = clips[2].length;
                break;
            }

            yield return new WaitForSeconds(length);

            Destroy(this.gameObject);
        }
    }
}

