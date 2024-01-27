using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace LJH{
    public class CursorManager : MonoBehaviour
    {

        public List<Texture2D> cursorIcon = new();
        public List<GameObject> selectImg = new();
        [SerializeField] int nowWeponNum = 0;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.SetCursor(cursorIcon[0],Vector2.zero, CursorMode.Auto);//게임 시작했을 땐, 커서를 0으로
        }

        // Update is called once per frame
        void Update()
        {
            CursorChange();
            
        }

        void CursorChange()
        {
            float wheelInput = Input.GetAxisRaw("Mouse ScrollWheel");
            if(wheelInput < -0.1f){//wheel down
                nowWeponNum -= 1;
                if(nowWeponNum < 0) {
                     nowWeponNum = cursorIcon.Count - 1;
                }
                Cursor.SetCursor(cursorIcon[nowWeponNum],Vector2.zero, CursorMode.Auto);
            }
            if(wheelInput > 0.1f){//wheel up
                nowWeponNum += 1;
                if(nowWeponNum > cursorIcon.Count - 1){
                    nowWeponNum = 0;
                }
                Cursor.SetCursor(cursorIcon[nowWeponNum],Vector2.zero, CursorMode.Auto);
            }
            for(int i = 0; i< cursorIcon.Count ;i++){
                if(i == nowWeponNum){
                    selectImg[i].SetActive(true);
                }
                else{
                    selectImg[i].SetActive(false);
                }
            }
        }        
    }

}
