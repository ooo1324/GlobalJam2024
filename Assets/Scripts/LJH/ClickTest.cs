using System.Collections;
using System.Collections.Generic;
using LJH;
using UnityEngine;

public class ClickTest : MonoBehaviour
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
            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero);

            // Ray가 어떤 Collider와 충돌했는지 확인
            if (hit.collider != null)
            {
                // 충돌한 오브젝트에 대한 처리
                Debug.Log("Clicked on: " + hit.collider.gameObject.name);
            }
        }
    }
}
