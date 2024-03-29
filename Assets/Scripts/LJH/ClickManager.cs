using Cinemachine;
using KSY;
using LJH;
using UnityEngine;

public class ClickManager : MonoBehaviour
{

    [SerializeField]
    private Camera UICam;

    [SerializeField]
    private Transform screenDownPos;

    private float xCorrection;

    private float yCorrection;
    // Start is called before the first frame update
    void Start()
    {
        xCorrection = screenDownPos.position.x * (1 / 14f);
        yCorrection = screenDownPos.position.y * (1 / 14f);
    }

    // Update is called once per frame
    void Update()
    {

        // 마우스 왼쪽 버튼이 눌렸을 때
        if (Input.GetMouseButtonDown(0))
        {

            // TODO : Test를 위해 임시 주석
            //switch(CursorManager.Instance.nowWeponNum){
            //        case 0:
            //            AudioManager.instance.Play("Sword");
            //        break;

            //        case 1:
            //            AudioManager.instance.Play("Wand");
            //        break;

            //        case 2:
            //            AudioManager.instance.Play("Gun");
            //        break;
            //    }


            RaycastHit2D hit;
            Vector2 screenPos = UICam.ScreenToWorldPoint(Input.mousePosition);

            // 마우스 포지션 보정
            Vector3 mousePoint = new Vector3((screenPos.x * (1 / 14f)) - xCorrection, (screenPos.y * (1 / 14f)) - yCorrection, -4);

            var ray = Camera.main.ViewportPointToRay(mousePoint);
            hit = Physics2D.GetRayIntersection(ray);

            CursorManager.Instance.ClickEffect(ray.origin);

            // Ray가 어떤 Collider와 충돌했는지 확인
            if (hit.collider != null)
            {
                //충돌했다면
                if (hit.collider.tag == "Enemy" && (CursorManager.Instance.nowWeponNum == 0 || CursorManager.Instance.nowWeponNum == 2))
                { 
                    //적이라면
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    if (enemy.GetHP() > GameManager.Instance.dmg)
                    { 
                        //데미지 초과의 hp가 남아있을땐
                        enemy.minusHP(GameManager.Instance.dmg); //hp 감소

                        HPBarScript hpbar = hit.transform.GetComponent<HPBarScript>();
                        for (int i = 0; i < GameManager.Instance.dmg; i++)
                        {
                            GameObject obj = hpbar.hpPop();
                            if (obj != null)
                                obj.SetActive(false); //객체 파괴
                        }
                    }
                    else
                    { 
                        //hp가 부족하다면 
                        Managers.Events.PlusScoreInvoke();
                        GameManager.Instance.RemoveEnemyObj(hit.collider.gameObject);
                    }
                }

                if (hit.collider.tag == "EnemyBoss" && (CursorManager.Instance.nowWeponNum == 0 || CursorManager.Instance.nowWeponNum == 2))
                {
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    if (enemy.GetHP() > GameManager.Instance.dmg)
                    {
                        enemy.minusHP(GameManager.Instance.dmg);

                        HPBarScript hPBar = hit.transform.GetComponent<HPBarScript>();
                        if (enemy.GetHP() % 10 == 0)
                        { //보스는 10단위로 hp Cell 제거
                            hPBar.hpPop().SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
