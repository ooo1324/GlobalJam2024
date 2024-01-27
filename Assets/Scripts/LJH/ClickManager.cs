using System.Collections;
using System.Collections.Generic;
using KSY;
using LJH;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 버튼이 눌렸을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 위치를 Ray로 변환
            // Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(EffectManager.Instance.mousePos, Vector2.zero);
            
            // Ray가 어떤 Collider와 충돌했는지 확인
            if (hit.collider != null)
            {
                //충돌했다면
                if(hit.collider.tag == "Enemy"){ //적이라면
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    if(enemy.GetHP() > 1){
                        enemy.minusHP(1); //hp 1 감소

                        HPBarScript hpbar = hit.transform.GetComponent<HPBarScript>();
                        Destroy(hpbar.hpPop()); //객체 파괴
                    }
                }
            }
        }
    }
}
