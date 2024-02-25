using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using KSY;
using LJH;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private float distanceToCamera;
    private CinemachineBrain cameraBrain;

    [SerializeField]
    private Camera UICamera;
    // Start is called before the first frame update
    void Start()
    {
        cameraBrain = Camera.main.GetComponent<CinemachineBrain>();
        
        cameraBrain.m_CameraCutEvent.AddListener((brain) =>
        {
            if (brain != null)
            {
                if (brain.ActiveVirtualCamera != null)
                {
                    // if virtual camera changed
                    distanceToCamera = Vector3.Distance(EffectManager.Instance.nowCam.transform.position, brain.ActiveVirtualCamera.VirtualCameraGameObject.transform.position);
                    Debug.Log("brain : " +brain.ActiveVirtualCamera.VirtualCameraGameObject.transform.position);
                }
            }
        });

        distanceToCamera = Vector3.Distance(EffectManager.Instance.nowCam.transform.position, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));

        rayPos = rayPos - new Vector3(3.3f, -1.3f, 0);
        Debug.DrawRay(rayPos, transform.forward * 15f, Color.red, 0.3f);
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


            // 마우스 위치를 Ray로 변환
            //Vector3 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //rayPos.z = -10;


           // Vector3 rayPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));
          
            //Old
            //RaycastHit2D hit = Physics2D.Raycast(EffectManager.Instance.mousePos, Vector2.zero);

            RaycastHit2D hit = Physics2D.Raycast(rayPos, transform.forward, 15f);
          
            Debug.Log($"x: {rayPos.x}, y: {rayPos.y}");


            // Ray가 어떤 Collider와 충돌했는지 확인
            if (hit.collider != null)
            {
                //충돌했다면
                if (hit.collider.tag == "Enemy" && (CursorManager.Instance.nowWeponNum == 0 || CursorManager.Instance.nowWeponNum == 2)){ //적이라면
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    if(enemy.GetHP() > GameManager.Instance.dmg){ //데미지 초과의 hp가 남아있을땐
                        enemy.minusHP(GameManager.Instance.dmg); //hp 감소

                        HPBarScript hpbar = hit.transform.GetComponent<HPBarScript>();
                        for(int i = 0;i < GameManager.Instance.dmg;i++)
                        {
                            GameObject obj = hpbar.hpPop();
                            if(obj != null)
                                obj.SetActive(false); //객체 파괴
                        }
                    } else{ //hp가 부족하다면 
                        Managers.Events.PlusScoreInvoke();
                        GameManager.Instance.RemoveEnemyObj(hit.collider.gameObject);
                    }
                }

                if(hit.collider.tag == "EnemyBoss" && (CursorManager.Instance.nowWeponNum == 0 || CursorManager.Instance.nowWeponNum == 2)){
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    if(enemy.GetHP() > GameManager.Instance.dmg){
                        enemy.minusHP(GameManager.Instance.dmg);

                        HPBarScript hPBar = hit.transform.GetComponent<HPBarScript>();
                        if(enemy.GetHP() % 10 == 0){ //보스는 10단위로 hp Cell 제거
                            hPBar.hpPop().SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
