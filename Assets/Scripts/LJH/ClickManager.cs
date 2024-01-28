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
                if(hit.collider.tag == "Enemy" && (CursorManager.Instance.nowWeponNum == 0 || CursorManager.Instance.nowWeponNum == 2)){ //적이라면
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    if(enemy.GetHP() > GameManager.Instance.dmg){ //데미지 초과의 hp가 남아있을땐
                        enemy.minusHP(GameManager.Instance.dmg); //hp 감소

                        HPBarScript hpbar = hit.transform.GetComponent<HPBarScript>();
                        for(int i = 0;i < GameManager.Instance.dmg;i++){

                            Destroy(hpbar.hpPop()); //객체 파괴
                        }
                    } else{ //hp가 부족하다면 
                        Managers.Events.PlusScoreInvoke();
                        GameManager.Instance.RemoveEnemyObj(hit.collider.gameObject);
                        Destroy(hit.collider.gameObject); //enemy를 파괴
                    }
                }

                if(hit.collider.tag == "EnemyBoss" && (CursorManager.Instance.nowWeponNum == 0 || CursorManager.Instance.nowWeponNum == 2)){
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    if(enemy.GetHP() > GameManager.Instance.dmg){
                        enemy.minusHP(GameManager.Instance.dmg);

                        HPBarScript hPBar = hit.transform.GetComponent<HPBarScript>();
                        if(enemy.GetHP() % 10 == 0){ //보스는 10단위로 hp Cell 제거
                            Destroy(hPBar.hpPop());
                        }
                    }
                }
            }
        }
    }
}
