using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using KSY;
using LJH;

public class WandColliderScript : MonoBehaviour
{
    //완드는 범위공격
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy" || other.tag == "EnemyBoss"){
            print("Wand");
            // Enemy enemy = other.transform.GetComponent<Enemy>();
            // if(enemy.GetHP() > GameManager.Instance.dmg){ //데미지 초과의 hp가 남아있을땐
            //     enemy.minusHP(GameManager.Instance.dmg); //hp 감소

            //     HPBarScript hpbar = other.transform.GetComponent<HPBarScript>();
            //     for(int i = 0;i < GameManager.Instance.dmg;i++){
            //         Destroy(hpbar.hpPop()); //객체 파괴
            //     }
            // } else{ //hp가 부족하다면 
            //     Destroy(other.gameObject); //enemy를 파괴
            // }
        }
    }
}
